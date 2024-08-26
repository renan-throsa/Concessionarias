using Concs.App.Configs;
using Concs.App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace Concs.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string _apiEndereco;

        public HomeController(ILogger<HomeController> logger, IOptions<ApiConfigs> appSettings)
        {
            _logger = logger;
            _apiEndereco = appSettings.Value.Endereco;
        }

        public IActionResult Index()
        {
            ViewBag.ApiEndereco = _apiEndereco;
            return View();
        }        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
