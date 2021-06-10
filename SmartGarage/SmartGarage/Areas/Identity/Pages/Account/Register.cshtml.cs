using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartGarage.Data.Models;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.CreateDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly IUserService _userService;
        private readonly IUserHelper _userHelper;
        private readonly UserManager<User> _userManager;

        public RegisterModel(
            SignInManager<User> signInManager,
            IUserService userService,
            IUserHelper userHelper,
            UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userService = userService;
            _userHelper = userHelper;
            _userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(20, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} symbols.")]
            [Display(Name = "User name")]
            public string UserName { get; set; }

            [Required]
            [StringLength(20, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} symbols.")]
            [Display(Name = "First name")]
            public string FirstName { get; set; }

            [Required]
            [StringLength(20, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} symbols.")]
            [Display(Name = "Family name")]
            public string LastName { get; set; }

            [Required]
            [RegularExpression(@"[0]{1}\d{9}", ErrorMessage = "Invalid phone number")]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Required]
            [Range(18, 100)]
            [Display(Name = "Age")]
            public int Age { get; set; }

            [Required]
            [StringLength(20, MinimumLength = 10, ErrorMessage = "{0} must be between {2} and {1} symbols.")]
            [Display(Name = "Driving license number")]
            public string DrivingLicenseNumber { get; set; }

            [Required]
            [Display(Name = "Address")]
            public string Address { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "E-mail")]
            public string Email { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            var emailExist = await _userManager.FindByEmailAsync(Input.Email);
            var userNameExist = await _userManager.FindByNameAsync(Input.UserName);

            if (emailExist != null || userNameExist != null)
            {
                TempData["Error"] = "User with this E-mail already exists.";
                return RedirectToAction("Index", "User");
            }

            if (ModelState.IsValid)
            {
                var userDTO = new CreateUserDTO
                {
                    UserName = Input.UserName,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    PhoneNumber = Input.PhoneNumber,
                    Age = Input.Age,
                    DrivingLicenseNumber = Input.DrivingLicenseNumber,
                    Address = Input.Address,
                    Email = Input.Email
                };

                try
                {
                    var result = await _userHelper.CreateUserAsync(userDTO);

                    TempData["Success"] = "Customer was registered.";

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }

                    return RedirectToAction("Index", "User");
                }
                catch (Exception)
                {
                    TempData["Error"] = "User with this E-mail already exists.";
                    return RedirectToAction("Index", "User");
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
