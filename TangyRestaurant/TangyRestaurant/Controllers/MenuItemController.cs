using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TangyRestaurant.Data;
using TangyRestaurant.Models;
using TangyRestaurant.Models.MenuItemsViewModels;
using TangyRestaurant.Utility;

namespace TangyRestaurant.Controllers
{
    [Authorize(Roles = SD.AdminAndUser)]
    public class MenuItemController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _hostingEnvironment; //This is to save the pictures to the server

        public MenuItemController(ApplicationDbContext db, IHostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;

            //Set the menuitemviewmodel
            this.menuItemsViewModel = new MenuItemsViewModel()
            {
                Categories = _db.Categories.ToList(),
                SubCategories = _db.SubCategories.ToList(),
                MenuItem = new MenuItem()
            };
        }

        [BindProperty]
        public MenuItemsViewModel menuItemsViewModel{ get; set; }

        [HttpGet]
        public IActionResult Index()
        {
            var menuItems = _db.MenuItems
                .Include(m => m.Category)
                .Include(m => m.SubCategory)
                .ToList();

            return View(menuItems); //pass it to the view
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(this.menuItemsViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MenuItem menuItem)
        {
            if (!ModelState.IsValid) {
                return View();
            }

            //set the category and subcategory to the menuItem
            menuItem.SubCategory = await _db.SubCategories.SingleOrDefaultAsync(sc => sc.Id == menuItem.SubCategoryId);
            menuItem.Category = await _db.Categories.SingleOrDefaultAsync(c => c.Id == menuItem.CategoryId);
            
            //save the menuItem
            await _db.MenuItems.AddAsync(menuItem);
            await _db.SaveChangesAsync();
            
            
            //Save the image to the images folder


            //01.We take the wwwRoot Folder path using the IHosting Environment
            string webRootPath = _hostingEnvironment.WebRootPath;

            //02.Take the uploaded file
            var files = HttpContext.Request.Form.Files;
            
            //03. We assign it to the actual menuItem that we just created
            MenuItem menuItemFromDb = _db.MenuItems.SingleOrDefault(m => m.Id == menuItem.Id);

            //if file has being uploaded
            if (files != null && files.Count > 0)
            {
                //04.Combine the webRoot path with the images
                var uploads = Path.Combine(webRootPath, "images");

                //05.Get the file extension
                var extension = files[0].FileName.Substring(files[0].FileName.LastIndexOf('.'), files[0].FileName.Length - files[0].FileName.LastIndexOf("."));

                //06.Copy the file to the folder by changing it's name with the menuitem id and the extension
                var fileStream = new FileStream(Path.Combine(uploads, menuItem.Id + extension), FileMode.Create);

                //Copy it to the new location
                files[0].CopyTo(fileStream);

                //07.We set the Image path on the menuItem
                menuItemFromDb.Image = @"/images/" + menuItem.Id + extension;

            }
            else
            {
                //When the image is not uploaded we set the default image
                
                //04.We take the path of the default-food-image
                var uploads = Path.Combine(webRootPath, "images/" + SD.defaultFoodImageName);

                //05.We copy the image and create the same image but with deferent name
                System.IO.File.Copy(uploads, webRootPath + @"/images/" + menuItem.Id + ".png");

                //06.Assign it to the menuItem
                menuItemFromDb.Image = @"/images/" + menuItem.Id + ".png";
            }
            
            await _db.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public JsonResult GetAllSubCategories() {

            var subCategories = _db.SubCategories.ToList();

            return Json(subCategories);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id) {

            if (id == null) {
                return NotFound();
            }

            menuItemsViewModel = new MenuItemsViewModel()
            {
                MenuItem = await _db.MenuItems.Include(m => m.Category).Include(m => m.SubCategory).SingleOrDefaultAsync(m => m.Id == id),
                Categories = await _db.Categories.ToListAsync(),
                SubCategories = await _db.SubCategories.ToListAsync()
            };

            if (menuItemsViewModel.MenuItem == null)
            {
                return NotFound();
            }
            
            return View(menuItemsViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, MenuItem menuItem)
        {
            if (!ModelState.IsValid)
            {
                this.menuItemsViewModel.SubCategories = await _db.SubCategories
                    .Where(s => s.categoryId == menuItemsViewModel.MenuItem.CategoryId)
                    .ToListAsync();

                this.menuItemsViewModel.Categories = await _db.Categories.ToListAsync();
                this.menuItemsViewModel.MenuItem = await _db.MenuItems.SingleOrDefaultAsync(m => m.Id == id);

                return View(this.menuItemsViewModel);
            }

            MenuItem menuItemFromDb = await _db.MenuItems.SingleOrDefaultAsync(m => m.Id == id);

            try
            {
                string webRootPath = _hostingEnvironment.WebRootPath;

                var files = HttpContext.Request.Form.Files;
                
                menuItem.Id = (int)id;

                if (files != null && files.Count > 0)
                {

                    var uploads = Path.Combine(webRootPath, "images");

                    var extension_new = files[0].FileName.Substring(files[0].FileName.LastIndexOf('.'), files[0].FileName.Length - files[0].FileName.LastIndexOf("."));
                    var extension_old = menuItemFromDb.Image.Substring(menuItemFromDb.Image.LastIndexOf('.'), menuItemFromDb.Image.Length - menuItemFromDb.Image.LastIndexOf("."));

                    //check if the old file exists
                    bool oldImageFileExists = System.IO.File.Exists(Path.Combine(uploads, menuItem.Id + extension_old));

                    if (oldImageFileExists)
                    {
                        //if the file exits we delete it
                        System.IO.File.Delete(Path.Combine(uploads, menuItem.Id + extension_old));

                        //Add the new file
                        var fileStream = new FileStream(Path.Combine(uploads, menuItem.Id + extension_new), FileMode.Create);

                        files[0].CopyTo(fileStream);
                    }

                    //we set it to the menuItem
                    menuItem.Image = @"/images/" + menuItem.Id + extension_new;
                }

                //If an image is uploaded then we will set it to the menuItemFromDb
                if (menuItem.Image != null)
                {
                    menuItemFromDb.Image = menuItem.Image;
                }

                //set everithing else

                menuItemFromDb.Name = menuItem.Name;
                menuItemFromDb.Description = menuItem.Description;
                menuItemFromDb.Price = menuItem.Price;
                menuItemFromDb.Spicyness = menuItem.Spicyness;
                menuItemFromDb.SubCategoryId = menuItem.SubCategoryId;
                menuItemFromDb.CategoryId = menuItem.CategoryId;
                
                await _db.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
            }

            return RedirectToAction(nameof(Index));

        }
        
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            MenuItem menuItem = await _db.MenuItems
                .Include(m => m.Category)
                .Include(m => m.SubCategory)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (menuItem == null)
            {
                return NotFound();
            }

            return View(menuItem);
        }
        
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            MenuItem menuItem = await _db.MenuItems
                .Include(m => m.Category)
                .Include(m => m.SubCategory)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (menuItem == null)
            {
                return NotFound();
            }

            return View(menuItem);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, MenuItem menuItemReceived)
        {
            if (id == null)
            {
                return NotFound();
            }
            MenuItem menuItem = await _db.MenuItems
                .SingleOrDefaultAsync(m => m.Id == id);
        
            if (menuItem == null)
            {
                return NotFound();
            }


            //We need to delete the image from the images folder
            string webRootPath = _hostingEnvironment.WebRootPath;

            var uploads = Path.Combine(webRootPath, "images");

            //ge tthe extension
            var extension = menuItem.Image.Substring(menuItem.Image.LastIndexOf('.'), menuItem.Image.Length - menuItem.Image.LastIndexOf("."));
            
            //we take the actual path of th image
            var imagePath = Path.Combine(uploads, menuItem.Id + extension);

            //we chack if it exists and if it does we delete it from the image folder
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }


            _db.MenuItems.Remove(menuItem);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        
    }
}