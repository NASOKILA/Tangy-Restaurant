using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TangyRestaurant.Data;
using TangyRestaurant.Models;
using TangyRestaurant.Utility;
using System.Security.Claims;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace TangyRestaurant.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;


        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ApplicationDbContext db,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _db = db;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
            
            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            
            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            
            [Required]
            [Phone]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser {
                    UserName = Input.Email,
                    Email = Input.Email,
                    PhoneNumber = Input.PhoneNumber,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName };


                //FIRST WE ADD THE USER AND THEN WE ADD THE ROLES TO IT.
                
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {

                    //Populate security stamp
                    await _userManager.UpdateSecurityStampAsync(user);
                    
                    //Create a role for the user with _roleManager

                    //First create the roles if they do not exit
                    if (!await _roleManager.RoleExistsAsync(SD.CustomerAndUser))
                    {

                        IdentityRole role = new IdentityRole()
                        {
                            Name = SD.CustomerAndUser,
                            NormalizedName = SD.CustomerAndUser.ToUpper()
                        };

                        await _roleManager.CreateAsync(role);
                        //await _db.SaveChangesAsync();
                    }

                    if (!await _roleManager.RoleExistsAsync(SD.AdminAndUser))
                    {

                        IdentityRole role = new IdentityRole()
                        {
                            Name = SD.AdminAndUser,
                            NormalizedName = SD.AdminAndUser.ToUpper()
                        };

                        await _roleManager.CreateAsync(role);
                        //await _db.SaveChangesAsync();
                    }

                    
                    //assign them to a user with user manager
                    if (_db.ApplicationUsers.Count() < 2)
                    {
                        await _userManager.AddToRoleAsync(user, SD.AdminAndUser);

                        //IMPORTANT : Add the role claim to the user
                        await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, SD.AdminAndUser));
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, SD.CustomerAndUser);

                        //IMPORTANT : Add the role claim to the user
                        await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, SD.CustomerAndUser));
                    }


                    //Set the session CartCount ot 0
                    //HttpContext.Session.SetInt32("CartCount", 0);



                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    //Set the session
                    HttpContext.Session.SetInt32("CartItems", 0);

                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
