using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TangyRestaurant.Data;
using TangyRestaurant.Models;
using TangyRestaurant.Models.HomeViewModel;

namespace TangyRestaurant.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            IndexViewModel indexViewModel = new IndexViewModel()
            {
                Categories = await _db.Categories.OrderBy(c => c.DisplayOrder).ToListAsync(),
                Coupons = await _db.Coupons.Where(c => c.IsActive == true).ToListAsync(), //we take only the active coupons
                MenuItems = await _db.MenuItems.Include(mi => mi.SubCategory).Include(mi => mi.Category).ToListAsync(),
                StatusMessage = ""
            };

            return View(indexViewModel);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            MenuItem menuItem = await _db.MenuItems
                .Include(m => m.Category)
                .Include(m => m.SubCategory)
                .SingleOrDefaultAsync(mi => mi.Id == id);

            if (menuItem == null)
            {
                return RedirectToAction(nameof(Index));
            }

            ShoppingCart shoppingCart = new ShoppingCart()
            {
                MenuItem = menuItem,
                MenuItemId = menuItem.Id,
                Count = 1
            };

            return View(shoppingCart);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Details(ShoppingCart shoppingCart)
        {

            MenuItem menuItem = await _db.MenuItems
               .Include(m => m.Category)
               .Include(m => m.SubCategory)
               .SingleOrDefaultAsync(mi => mi.Id == shoppingCart.MenuItem.Id);

            if (!ModelState.IsValid)
            {
                shoppingCart.MenuItem = menuItem;
                return View(shoppingCart);
            }

            ApplicationUser currentUserFromDb = (ApplicationUser)await _db.Users.SingleOrDefaultAsync(u => u.Email == User.Identity.Name);

            ShoppingCart shoppingCartFromDB = await _db.ShoppingCarts
                    .SingleOrDefaultAsync(sc => sc.ApplicationUserId == currentUserFromDb.Id
                    && sc.MenuItemId == menuItem.Id);

            if (shoppingCartFromDB == null)
            {
                ShoppingCart shoppingCartToSave = new ShoppingCart()
                {
                    MenuItem = menuItem,
                    MenuItemId = menuItem.Id,
                    Count = shoppingCart.Count,
                    ApplicationUser = currentUserFromDb,
                    ApplicationUserId = currentUserFromDb.Id
                };

                await _db.ShoppingCarts.AddAsync(shoppingCartToSave);
            }
            else
            {
                shoppingCartFromDB.Count += shoppingCart.Count;
                _db.ShoppingCarts.Update(shoppingCartFromDB);
            }

            await _db.SaveChangesAsync();

            int userCartItemsCount = _db.ShoppingCarts.Where(s => s.ApplicationUserId == currentUserFromDb.Id).ToList().Count;

            HttpContext.Session.SetInt32("CartItems", userCartItemsCount);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
