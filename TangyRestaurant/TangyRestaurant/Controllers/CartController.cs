using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TangyRestaurant.Data;
using TangyRestaurant.Models;
using Microsoft.EntityFrameworkCore;
using TangyRestaurant.Models.OrderDetailsViewModel;
using System.Security.Claims;
using TangyRestaurant.Utility;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using TangyRestaurant.Services;

namespace TangyRestaurant.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _db;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartController(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }

        [BindProperty]
        public OrderDetailsCart OrderDetailsCart { get; set; }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //Get CurrentUserId from Claims
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            string cuttentUserId = claim.Value;
            
            var cart = await _db.ShoppingCarts
                    .Include(s => s.MenuItem)
                    .Include(s => s.ApplicationUser)
                    .Where(sc => sc.ApplicationUserId == cuttentUserId).ToListAsync();
            
            if (cart == null)
            {
                return NotFound();
            }
            
            this.OrderDetailsCart = new OrderDetailsCart()
            {
                OrderHeader = new OrderHeader()
                {
                    OrderTotal = 0,
                    UserId = claim.Value
                },
                ShoppingCart = cart
            };
            
            foreach (var item in OrderDetailsCart.ShoppingCart)
            {
                item.MenuItem.Description = item.MenuItem.Description.Substring(0, Math.Min(SD.MenuItemDesctiptionMaxSimbols, item.MenuItem.Description.Length));

                if (item.MenuItem.Description.Length > SD.MenuItemDesctiptionMaxSimbols)
                {
                    item.MenuItem.Description += SD.MenuItemDesctiptionDots;
                }
            }
            
            return View(OrderDetailsCart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")] // we define the action name as well
        public async Task<IActionResult> IndexPost()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;

            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            string cuttentUserId = claim.Value;

            //Get Items of shopping cart
            List<ShoppingCart> shoppingCart = _db.ShoppingCarts.Include(sc => sc.MenuItem).Where(sc => sc.ApplicationUserId == claim.Value).ToList();

            //get order header and populate it
            OrderHeader orderHeader = this.OrderDetailsCart.OrderHeader;
            orderHeader.OrderDate = DateTime.Now;
            orderHeader.Status = SD.StatusSubmitted;
            
            //save it to the Database
            await _db.OrderHeaders.AddAsync(orderHeader);
            
            //Populate each ShoppingCart item, we only have the menuitem id for now
            foreach (ShoppingCart item in shoppingCart)
            {
                item.MenuItem = await _db.MenuItems.SingleOrDefaultAsync(m => m.Id == item.MenuItemId);

                OrderDetails orderDetails = new OrderDetails()
                {
                    MenuItem = item.MenuItem,
                    MenuItemId = item.MenuItemId,
                    OrderHeader = orderHeader,
                    OrderHeaderId = item.MenuItem.Id,
                    Price = item.MenuItem.Price,
                    Count = item.Count,
                    Description = orderHeader.Comments,
                    Name = item.MenuItem.Name 
                };

                await _db.OrderDetails.AddAsync(orderDetails);
            }

            await _db.SaveChangesAsync();

            //Empty shopping cart and session
           
            _db.ShoppingCarts.RemoveRange(shoppingCart);
            await _db.SaveChangesAsync();

            this._httpContextAccessor.HttpContext.Session.SetInt32("CartItems", 0);

            //Send mail for creation
            EmailSender emailSender = new EmailSender();

            await Extensions.EmailSenderExtensions.SendOrderStatusAsync(emailSender, this.User.Identity.Name, orderHeader.Id.ToString(), orderHeader.Status);


            return RedirectToAction("Confirm", "Order", new { id= orderHeader.Id});
        }

        public async Task<IActionResult> IncreaseCount(int cartId)
        {
            ShoppingCart currentCart = await _db.ShoppingCarts.SingleOrDefaultAsync(sc => sc.Id == cartId);

            currentCart.Count = currentCart.Count + 1;

            _db.ShoppingCarts.Update(currentCart);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DecreaseCount(int cartId)
        {
            ShoppingCart currentCart = await _db.ShoppingCarts.SingleOrDefaultAsync(sc => sc.Id == cartId);
            int cartCount = _db.ShoppingCarts.Where(sc => sc.ApplicationUserId == currentCart.ApplicationUserId).Count();

            if (currentCart.Count == 1)
            {
                _db.ShoppingCarts.Remove(currentCart);

                //reset session once you remove an item from cart
                _httpContextAccessor.HttpContext.Session.SetInt32("CartItems", cartCount - 1);
            }
            else
            {
                currentCart.Count = currentCart.Count - 1;
                _db.ShoppingCarts.Update(currentCart);
            }

            await _db.SaveChangesAsync();



            return RedirectToAction("Index");
        }

    }
}
