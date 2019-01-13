using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TangyRestaurant.Data;
using TangyRestaurant.Models;
using TangyRestaurant.Models.OrderDetailsViewModel;
using TangyRestaurant.Services;
using TangyRestaurant.Utility;

namespace TangyRestaurant.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;

        private int PageSize = 2;

        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Confirm(int? id)
        {
            ClaimsIdentity claimsIdentity = (ClaimsIdentity)this.User.Identity;

            Claim claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            string userId = claim.Value;

            OrderDetailsViewModel orderDetailsViewModel = new OrderDetailsViewModel()
            {
                OrderHeader = await _db.OrderHeaders.SingleOrDefaultAsync(oh => oh.Id == id && oh.UserId == userId),
                OrderDetailsList = await _db.OrderDetails
                    .Include(od => od.MenuItem)
                    .Where(od => od.OrderHeaderId == id)
                    .ToListAsync()
            };

            return View(orderDetailsViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> History(int productPage = 1)
        {
            PagingInfo paging = new PagingInfo();

            paging.CurrentPage = (int)productPage;

            ClaimsIdentity claimsIdentity = (ClaimsIdentity)this.User.Identity;

            Claim claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            string userId = claim.Value;

            HistoryViewModel historyViewModel = new HistoryViewModel()
            {
                Orders = new List<OrderDetailsViewModel>()
            };


            List<OrderHeader> userOrderHeadersList = _db.OrderHeaders.Where(oh => oh.UserId == userId).OrderByDescending(oh => oh.OrderDate).ToList();

            foreach (var item in userOrderHeadersList)
            {
                historyViewModel.Orders.Add(
                    new OrderDetailsViewModel()
                    {
                        OrderHeader = item,
                        OrderDetailsList = await _db.OrderDetails
                            .Include(od => od.MenuItem)
                            .Where(od => od.OrderHeaderId == item.Id)
                            .ToListAsync()
                    }
                );
            }

            int totalOrderCount = historyViewModel.Orders.Count;

            //We order them then skip and take whatever pages we need for the pagination.
            historyViewModel.Orders = historyViewModel.Orders
                .OrderBy(p => p.OrderHeader.Id)
                .Skip((productPage - 1) * this.PageSize).Take(PageSize)
                .ToList();

            //Set the pagination object.
            historyViewModel.PagingInfo = new PagingInfo()
            {
                CurrentPage = productPage,
                ItemsPerPage = this.PageSize,
                TotalItems = totalOrderCount
            };

            return View(historyViewModel);
        }

        [HttpGet]
        [Authorize(Roles = SD.AdminAndUser)]
        public async Task<IActionResult> Manage()
        {
            List<OrderDetailsViewModel> orderDetailsViewModelList = new List<OrderDetailsViewModel>();

            List<OrderHeader> userOrderHeadersList = _db.OrderHeaders
                .Where(oh => oh.Status == SD.StatusSubmitted || oh.Status == SD.StatusInProcess)
                .OrderByDescending(oh => oh.OrderDate)
                .ToList();

            foreach (var item in userOrderHeadersList)
            {
                orderDetailsViewModelList.Add(
                    new OrderDetailsViewModel()
                    {
                        OrderHeader = item,
                        OrderDetailsList = await _db.OrderDetails
                            .Include(od => od.MenuItem)
                            .Where(od => od.OrderHeaderId == item.Id)
                            .ToListAsync()
                    }
                );
            }

            return View(orderDetailsViewModelList);
        }

        [HttpGet]
        [Authorize(Roles = SD.AdminAndUser)]
        public async Task<IActionResult> Pickup(string email = null, string orderNumber = null, string phoneNumber = null)
        {
            List<OrderDetailsViewModel> orderDetailsViewModelList = new List<OrderDetailsViewModel>();

            List<OrderHeader> userOrderHeadersList = new List<OrderHeader>();

            if (email != null)
            {
                userOrderHeadersList = _db.OrderHeaders
                    .Include(oh => oh.User)
                    .Where(oh => oh.User.Email == email)
                    .OrderByDescending(oh => oh.OrderDate)
                    .ToList();
            }
            else if (orderNumber != null)
            {
                userOrderHeadersList = _db.OrderHeaders
                    .Where(oh => oh.Id.ToString() == orderNumber)
                    .OrderByDescending(oh => oh.OrderDate)
                    .ToList();
            }
            else if (phoneNumber != null)
            {
                userOrderHeadersList = _db.OrderHeaders
                    .Include(oh => oh.User)
                    .Where(oh => oh.User.PhoneNumber.Contains(phoneNumber))
                    .OrderByDescending(oh => oh.OrderDate)
                    .ToList();
            }
            else
            {
                userOrderHeadersList = _db.OrderHeaders
                    .Where(oh => oh.Status == SD.StatusReady)
                    .OrderByDescending(oh => oh.OrderDate)
                    .ToList();
            }

            foreach (var item in userOrderHeadersList)
            {
                orderDetailsViewModelList.Add(
                    new OrderDetailsViewModel()
                    {
                        OrderHeader = item,
                        OrderDetailsList = await _db.OrderDetails
                            .Include(od => od.MenuItem)
                            .Where(od => od.OrderHeaderId == item.Id)
                            .ToListAsync()
                    }
                );
            }

            return View(orderDetailsViewModelList);
        }

        [HttpGet]
        [Authorize(Roles = SD.AdminAndUser)]
        public async Task<IActionResult> ConfirmPickupDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var header = await _db.OrderHeaders.Include(od => od.User).SingleOrDefaultAsync(oh => oh.Id == id);

            var details = await _db.OrderDetails.Include(od => od.MenuItem).Where(od => od.OrderHeaderId == header.Id).ToListAsync();

            OrderDetailsViewModel orderDetailsViewModelList = new OrderDetailsViewModel
            {
                OrderHeader = header,
                OrderDetailsList = details
            };

            return View(orderDetailsViewModelList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.AdminAndUser)]
        [ActionName("ConfirmPickupDetails")]
        public async Task<IActionResult> Completed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderHeader orderHeader = await _db.OrderHeaders.Include(oh => oh.User).SingleOrDefaultAsync(oh => oh.Id == id);

            if (orderHeader == null)
            {
                return NotFound();
            }

            orderHeader.Status = SD.StatusCompleted;

            _db.OrderHeaders.Update(orderHeader);

            await _db.SaveChangesAsync();

            string email = orderHeader.User.Email;

            EmailSender emailSender = new EmailSender();

            await Extensions.EmailSenderExtensions.SendOrderStatusAsync(emailSender, email, orderHeader.Id.ToString(), orderHeader.Status);

            return RedirectToAction(nameof(Manage));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.AdminAndUser)]
        public async Task<IActionResult> Ready(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderHeader orderHeader = await _db.OrderHeaders.Include(oh => oh.User).SingleOrDefaultAsync(oh => oh.Id == id);

            if (orderHeader == null)
            {
                return NotFound();
            }

            orderHeader.Status = SD.StatusReady;

            _db.OrderHeaders.Update(orderHeader);

            await _db.SaveChangesAsync();

            string email = orderHeader.User.Email;

            EmailSender emailSender = new EmailSender();

            await Extensions.EmailSenderExtensions.SendOrderStatusAsync(emailSender, email, orderHeader.Id.ToString(), orderHeader.Status);

            return RedirectToAction(nameof(Manage));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.AdminAndUser)]
        public async Task<IActionResult> InProgress(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderHeader orderHeader = await _db.OrderHeaders.Include(oh => oh.User).SingleOrDefaultAsync(oh => oh.Id == id);

            if (orderHeader == null)
            {
                return NotFound();
            }

            orderHeader.Status = SD.StatusInProcess;

            _db.OrderHeaders.Update(orderHeader);

            await _db.SaveChangesAsync();

            string email = orderHeader.User.Email;

            EmailSender emailSender = new EmailSender();

            await Extensions.EmailSenderExtensions.SendOrderStatusAsync(emailSender, email, orderHeader.Id.ToString(), orderHeader.Status);


            return RedirectToAction(nameof(Manage));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.AdminAndUser)]
        public async Task<IActionResult> Cancel(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderHeader orderHeader = await _db.OrderHeaders.Include(oh => oh.User).SingleOrDefaultAsync(oh => oh.Id == id);

            if (orderHeader == null)
            {
                return NotFound();
            }

            orderHeader.Status = SD.StatusCancelled;

            _db.OrderHeaders.Update(orderHeader);

            await _db.SaveChangesAsync();

            string email = orderHeader.User.Email;

            EmailSender emailSender = new EmailSender();

            await Extensions.EmailSenderExtensions.SendOrderStatusAsync(emailSender, email, orderHeader.Id.ToString(), orderHeader.Status); 
            
            return RedirectToAction(nameof(Manage));
        }

        [HttpGet]
        [Authorize(Roles = SD.AdminAndUser)]
        public IActionResult DownloadOrderDetails()
        {
            DatesForCsvViewModel datesForCsv = new DatesForCsvViewModel()
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
            };
            return View(datesForCsv);
        }

        [HttpPost]
        [Authorize(Roles = SD.AdminAndUser)]
        public IActionResult DownloadOrderDetails(DatesForCsvViewModel datesForCsvViewModel)
        {
            string[] columnNames = new string[] { "Id", "OrderId", "Count", "Name", "Price" };

            List<OrderDetails> results = _db.OrderDetails
                .Include(od => od.MenuItem)
                .Include(od => od.OrderHeader)
                .Where(od => od.OrderHeader.OrderDate >= datesForCsvViewModel.StartDate && od.OrderHeader.OrderDate <= datesForCsvViewModel.EndDate)
                .ToList();

            DataTable DataTable = ConvertListToDataTable(columnNames, results);

            StringBuilder builder = new StringBuilder();

            builder.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in DataTable.Rows)
            {
                string[] fields = row.ItemArray.Select(field => field.ToString()).
                                                ToArray();

                builder.AppendLine(string.Join(",", fields));
            }

            string fileName = "myfile.csv";

            string r = ConvertToString(results);

            return File(new UTF8Encoding().GetBytes(r), "text/csv", fileName);

        }

        private static DataTable ConvertListToDataTable(string[] columnNames, List<OrderDetails> list)
        {
            DataTable table = new DataTable();

            foreach (string column in columnNames)
            {
                table.Columns.Add(column);
            }

            foreach (var orderDetail in list)
            {

                string[] row = new string[] { orderDetail.Id.ToString(), orderDetail.Id.ToString(), orderDetail.Count.ToString(), orderDetail.Name, orderDetail.Price.ToString() };

                table.Rows.Add(row);
            }

            return table;
        }

        public String ConvertToString<T>(IList<T> data)
        {

            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable();

            foreach (PropertyDescriptor prop in properties)
            {

                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            }

            foreach (T item in data)
            {

                DataRow row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)

                {

                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;

                }

                table.Rows.Add(row);

            }

            StringBuilder sb = new StringBuilder();

            IEnumerable<string> columnNames = table.Columns.Cast<DataColumn>().Select(column => column.ColumnName);

            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in table.Rows)
            {

                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());

                sb.AppendLine(string.Join(",", fields));

            }

            return sb.ToString();

        }

    }
}