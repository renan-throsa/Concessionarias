using Concs.Dominio.Modelos;
using Concs.Web.Clients;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace Concs.Web.Controllers
{

    public class UsuarioController : Controller
    {

        private readonly IUsuarioClient _usuarioClient;

        public UsuarioController(IUsuarioClient usuarioClient)
        {
            _usuarioClient = usuarioClient;
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
                var token = await response.Content.ReadAsStringAsync();

                var resultado = new JwtSecurityToken(jwtEncodedString: token);

                var claimsIdentity = new ClaimsIdentity(resultado.Claims.Append(new Claim("token", token)), CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = resultado.ValidTo,
                    IsPersistent = modeloAutencicaçãoUsuario.LembrasSe,
                    IssuedUtc = resultado.IssuedAt,
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

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
        public async Task<IActionResult> Sair()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Autenticar", "Usuario");
        }
    }
}
