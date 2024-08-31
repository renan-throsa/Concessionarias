using Concs.App.Configs;
using Concs.App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace Concs.App.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly string _apiEndereco;

        public HomeController(ILogger<HomeController> logger, IOptions<ApiConfigs> appSettings)
        {
            _logger = logger;
            _apiEndereco = appSettings.Value.WebParaApiEndereco;
        }

        public IActionResult Index()
        {
            ViewBag.ApiEndereco = _apiEndereco;
            ViewBag.ApiToken = HttpContext.User.HasClaim(x => x.Type == "token") ? HttpContext.User.Claims.First(x => x.Type == "token").Value : "";
            ViewBag.PodeLer = HttpContext.User.HasClaim("Permissões", "Relatorio.Ler");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
