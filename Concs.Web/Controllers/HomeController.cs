using Concs.App.Configs;
using Concs.App.Models;
using Concs.Web.Serviços;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace Concs.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsuarioServiço _serviço;
        private readonly ILogger<HomeController> _logger;
        private readonly string _apiEndereco;

        public HomeController(IUsuarioServiço serviço,ILogger<HomeController> logger, IOptions<ApiConfigs> appSettings)
        {
            _serviço = serviço;
            _logger = logger;
            _apiEndereco = appSettings.Value.WebParaApiEndereco;
        }

        public IActionResult Index()
        {
            ViewBag.ApiEndereco = _apiEndereco;
            ViewBag.Usuario = _serviço.ObterToken();
            return View();
        }        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
