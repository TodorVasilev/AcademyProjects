using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartGarage.Contracts;
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

        public RegisterModel(
            SignInManager<User> signInManager,
            IUserService userService,
            IUserHelper userHelper)
        {
            _signInManager = signInManager;
            _userService = userService;
            _userHelper = userHelper;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [MinLength(2), MaxLength(20)]
            [Display(Name = "User name")]
            public string UserName { get; set; }

            [Required]
            [MinLength(2), MaxLength(20)]
            [Display(Name = "First name")]
            public string FirstName { get; set; }

            [Required]
            [MinLength(2), MaxLength(20)]
            [Display(Name = "Family name")]
            public string LastName { get; set; }

            [StringLength(10)]
            [DataType(DataType.PhoneNumber)]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Required]
            [Range(18, 100)]
            [Display(Name = "Age")]
            public int Age { get; set; }

            [Required]
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

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }

                    return RedirectToPage("./Login");
                }
                catch (Exception)
                {
                    return RedirectToPage("./Login");
                }

            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
