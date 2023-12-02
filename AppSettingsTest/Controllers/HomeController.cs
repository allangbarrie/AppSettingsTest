using AppSettingsTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppSettingsTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration iConfig)
        {
            _logger = logger;
            configuration = iConfig;
        }

        public IActionResult Index()
        {

            string mailSecret = configuration.GetValue<string>("ApplicationSecrets:MailSecret");

            ViewData["MailPassword"] = mailSecret;

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