using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TangyRestaurant.Data;
using TangyRestaurant.Models;

namespace TangyRestaurant.ViewComponents
{

    //The file needs to end in "ViewComponnt"
    //We inherit the ViewComponent class to let .net core know that this is a ViewVomponent
    public class UserNameViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;

        public UserNameViewComponent(ApplicationDbContext db)
        {
            _db = db;
        }

        //We create the method for invoking this ViewComponnet !
        //It returns IViewComponentResult
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ClaimsIdentity claimsIdentity = (ClaimsIdentity)this.User.Identity;

            Claim claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            string userId = claim.Value;
            
            ApplicationUser currentUser = await _db.Users.SingleOrDefaultAsync(u => u.Id == userId) as ApplicationUser;

            //We return the current user to the view
            return View(currentUser);

            //WE NEED TO CREATE THE VIEW FOR OUR VIEW COMPONENT
        }
    }
}
