using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using TangyRestaurant.Utility;

namespace TangyRestaurant.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = SD.FirstName)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = SD.LastName)]
        public string LastName { get; set; }

        [Display(Name = SD.LockoutReason)]
        public string LockoutReason { get; set; }
    }
}
