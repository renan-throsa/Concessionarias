using Concs.App.Clients;
using Concs.Dominio.Modelos;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Concs.App.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        private readonly IClienteClient _clienteClient;

        public ClienteController(IClienteClient clienteClient)
        {
            _clienteClient = clienteClient;
        }

        
        public async Task<ActionResult> Listagem()
        {
            var vm = await _clienteClient.Listagem();
            ViewBag.PodeInserir = HttpContext.User.HasClaim("Permissões", "Cliente.Inserir");
            return View(vm);
        }

        public async Task<ActionResult> Criar()
        {
           
            ViewBag.Erros = new List<string>();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Criar(ModeloInserçãoCliente modeloInserçãoCliente)
        {
            var response = await _clienteClient.Inserir(modeloInserçãoCliente);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Listagem", "Cliente");
            }

            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var result = await response.Content.ReadAsStringAsync();
            var erro = JsonSerializer.Deserialize<ValidationResult>(result, option);

           
            ViewBag.Erros = erro.Errors.Select(x => x.ErrorMessage).ToList();

            return View(modeloInserçãoCliente);
        }


        [HttpGet]
        public async Task<ActionResult> Editar(int id)
        {
            var response = await _clienteClient.Encontrar(id);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var model = JsonSerializer.Deserialize<ModeloAtualizaçãoCliente>(result, option);

                ViewBag.Erros = new List<string>();               

                return View(model);
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(ModeloAtualizaçãoCliente modeloAtualizaçãoCliente)
        {
            var response = await _clienteClient.Atualizar(modeloAtualizaçãoCliente);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Listagem", "Cliente");
            }

            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var result = await response.Content.ReadAsStringAsync();
            var erros = JsonSerializer.Deserialize<ValidationResult>(result, option);
           
            ViewBag.Erros = erros.Errors.Select(x => x.ErrorMessage).ToList();


            return View(modeloAtualizaçãoCliente);
        }
    }
}
