using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartGarage.Models;
using SmartGarage.Service.Helpers;
using SmartGarage.Service.ServiceContracts;
using SmartGarage.ViewModels;
using System.Diagnostics;

namespace SmartGarage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailsService emailService;

        public HomeController(ILogger<HomeController> logger, IEmailsService emailService)
        {
            _logger = logger;
            this.emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RecieveEmail(RecieveEmailViewModel recieveEmailModel)
        {
            emailService.RecieveEmail(recieveEmailModel);
            TempData["Success"] = "Email was send succefully";
            return View();
        }
    }
}
