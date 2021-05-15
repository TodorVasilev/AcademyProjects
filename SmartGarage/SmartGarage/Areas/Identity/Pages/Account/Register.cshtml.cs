using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using SmartGarage.Data.Models;
using SmartGarage.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace SmartGarage.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailsService _emailSender;

        public RegisterModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<RegisterModel> logger,
            IEmailsService emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
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
            var passwordLength = 12;
            var password = CreatePassword(passwordLength);

            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    PhoneNumber = Input.PhoneNumber,
                    Age = Input.Age,
                    DrivingLicenseNumber = Input.DrivingLicenseNumber,
                    Address = Input.Address,
                    UserName = Input.UserName,
                    Email = Input.Email
                };

                var result = await _userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendRegistrationEmail(Input.Email, "sads");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return RedirectToPage("./Login");
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
        private string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            const string ensureIsValid = "aA1";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString() + ensureIsValid;
        }
    }
}
