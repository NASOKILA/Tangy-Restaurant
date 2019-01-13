using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TangyRestaurant.Data;
using TangyRestaurant.Utility;

namespace TangyRestaurant.Controllers.API
{
    [Authorize(Roles = SD.AdminAndUser)]
    public class UserAPIController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserAPIController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get(string type, string query=null)
        {
            if (type.Equals("email") && query != null)
            {
                var result = _db.Users
                    .Where(u => u.Email.ToLower().Contains(query.ToLower()))
                    .ToList();

                return Ok(result);
            }

            return Ok();
        }
    }
}