using AppSettingsTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppSettingsTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAppConfig _appconfig;

        public HomeController(ILogger<HomeController> logger, IAppConfig appconfig)
        {
            _logger = logger;
            _appconfig = appconfig;
        }

        public IActionResult Index()
        {

            var mailSecret = _appconfig.GetMailSecret();
            var adminSecret = _appconfig.GetAdminPass();

            ViewData["MailPassword"] = mailSecret;
            ViewData["AdminPassword"] = adminSecret;

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
    }
}