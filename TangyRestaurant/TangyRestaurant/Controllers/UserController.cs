using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TangyRestaurant.Data;
using TangyRestaurant.Models;
using TangyRestaurant.Utility;

namespace TangyRestaurant.Controllers
{
    [Authorize(Roles = SD.AdminAndUser)]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [BindProperty]
        public ApplicationUser CurrentUser { get; set; }

        [HttpGet]
        public async Task<IActionResult> Index() {

            List<ApplicationUser> users = new List<ApplicationUser>();

            string userName = User.Identity.Name;

            List<IdentityUser> usersFromDb = await _db
                .Users
                .Where(u => u.UserName != User.Identity.Name)
                .ToListAsync();
            
            foreach (var u in usersFromDb)
            {
                ApplicationUser user = u as ApplicationUser;
                users.Add(user);
            }


            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id) {

            if (id == "") {
                return NotFound();
            }

            CurrentUser = await _db.Users.SingleOrDefaultAsync(u => u.Id == id) as ApplicationUser;

            if (CurrentUser == null) {
                return NotFound();
            }

            return View(CurrentUser);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(string id)
        {

            ApplicationUser user = await _db.Users.SingleOrDefaultAsync(u => u.Id == id) as ApplicationUser;

            if (user == null) {
                return NotFound();
            }

            if (!ModelState.IsValid) {
                return RedirectToAction(nameof(Edit));
            }


            user.FirstName= CurrentUser.FirstName;
            user.LastName  = CurrentUser.LastName;
            user.Email = CurrentUser.Email;
            user.PhoneNumber = CurrentUser.PhoneNumber;
            user.LockoutEnd = CurrentUser.LockoutEnd;
            user.LockoutReason = CurrentUser.LockoutReason;
            user.AccessFailedCount = CurrentUser.AccessFailedCount;


            _db.Users.Update(user);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        
        [HttpGet]
        public async Task<IActionResult> Lock(string id)
        {
            ApplicationUser user = await _db.Users.SingleOrDefaultAsync(u => u.Id == id) as ApplicationUser;

            bool userIsLocked = user.LockoutEnd != null;
            if (userIsLocked)
            {
                //user is locked
                return RedirectToAction(nameof(Unlock), new { id = user.Id });
            }

            if (user == null)
            {
                return NotFound();
            }
            
            return View(user);
        }
        
        [HttpPost]
        public async Task<IActionResult> Lock(string id, DateTime lockoutEnd, string lockoutReason) {
            
            ApplicationUser user = await _db.Users.SingleOrDefaultAsync(u => u.Id == id) as ApplicationUser;

            bool userIsLocked = user.LockoutEnd != null;
            if (userIsLocked) {
                //user is locked
                return RedirectToAction(nameof(Unlock), new { id = user.Id });
            }

            if (user == null)
            {
                return NotFound();
            }

            if (lockoutEnd == null) {
                lockoutEnd = DateTime.Now;
                lockoutEnd = lockoutEnd.AddMinutes(5);
            }
            user.LockoutReason = lockoutReason;
            user.LockoutEnd = lockoutEnd;

            _db.Users.Update(user);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        
        [HttpGet]
        public async Task<IActionResult> Unlock(string id)
        {
            ApplicationUser user = await _db.Users.SingleOrDefaultAsync(u => u.Id == id) as ApplicationUser;

            bool userIsLocked = user.LockoutEnd != null;
            if (!userIsLocked)
            {
                //user is locked
                return RedirectToAction(nameof(Lock), new { id = user.Id });
            }

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        
        [HttpPost]
        public async Task<IActionResult> UnlockAsync(string id)
        {

            ApplicationUser user = await _db.Users.SingleOrDefaultAsync(u => u.Id == id) as ApplicationUser;

            bool userIsLocked = user.LockoutEnd != null;
            if (!userIsLocked)
            {
                //user is not locked
                return RedirectToAction(nameof(Lock), new { id = user.Id });
            }

            if (user == null)
            {
                return NotFound();
            }

            DateTime lockoutTime = DateTime.Now;

            user.LockoutEnd = null;
            user.LockoutReason = "";
            
            _db.Users.Update(user);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        
    }
}
