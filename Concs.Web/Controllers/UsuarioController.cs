using Concs.Dominio.Modelos;
using Concs.Web.Clients;
using Concs.Web.Serviços;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Concs.Web.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IUsuarioClient _usuarioClient;
        private readonly IUsuarioServiço _usuarioServiço;

        public UsuarioController(IUsuarioClient usuarioClient, IUsuarioServiço usuarioServiço)
        {
            _usuarioClient = usuarioClient;
            _usuarioServiço = usuarioServiço;
        }

        [HttpGet]
        public IActionResult Autenticar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Autenticar(ModeloAutencicaçãoUsuario modeloAutencicaçãoUsuario)
        {
            var response = await _usuarioClient.Autenticar(modeloAutencicaçãoUsuario);

            if (response.IsSuccessStatusCode)
            {
                _usuarioServiço.GuardarUsuario(await response.Content.ReadAsStringAsync());
                return RedirectToAction("Index", "Home");
            }

            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var result = await response.Content.ReadAsStringAsync();
            var erro = JsonSerializer.Deserialize<ValidationResult>(result, option);

            ViewBag.Erros = erro.Errors.Select(x => x.ErrorMessage).ToList();

            return View(modeloAutencicaçãoUsuario);
        }

        [HttpPost]
        public IActionResult Sair()
        {
            _usuarioServiço.ApagarUsuario();
            return RedirectToAction("Autenticar", "Usuario");
        }
    }
}
