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
            ViewBag.PodeAtualizar = HttpContext.User.HasClaim("Permissões", "Cliente.Atualizar");
            return View(vm);
        }

        public async Task<ActionResult> Criar()
        {
           
            ViewBag.Erros = new List<string>();
            return View();
        }


        [HttpPost]        
        public async Task<ActionResult> Criar(ModeloInserçãoCliente modeloInserçãoCliente)
        {
            var response = await _clienteClient.Inserir(modeloInserçãoCliente);

            if (response.IsSuccessStatusCode)
            {
                TempData["MemsagemDeSucesso"] = "Novo cliente registrado !";
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

        public async Task<ActionResult> Editar(ModeloAtualizaçãoCliente modeloAtualizaçãoCliente)
        {
            var response = await _clienteClient.Atualizar(modeloAtualizaçãoCliente);

            if (response.IsSuccessStatusCode)
            {
                TempData["MemsagemDeSucesso"] = "Alterações salvas com sucesso !";
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

        [HttpGet]
        public async Task<ActionResult> Detalhes(int id)
        {
            var response = await _clienteClient.Encontrar(id);
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            if (response.IsSuccessStatusCode)
            {
                var sucssesResult = await response.Content.ReadAsStringAsync();

                var model = JsonSerializer.Deserialize<ModeloVisualizaçãoCliente>(sucssesResult, option);

                ViewBag.Erros = new List<string>();
                ViewBag.PodeAtualizar = HttpContext.User.HasClaim("Permissões", "Cliente.Atualizar");
                return View(model);
            }


            var erroResult = await response.Content.ReadAsStringAsync();
            var erros = JsonSerializer.Deserialize<ValidationResult>(erroResult, option);

            ViewBag.Erros = erros.Errors.Select(x => x.ErrorMessage).ToList();
            return View();
        }

        [HttpPost]

        public async Task<ActionResult> Detalhes(ModeloVisualizaçãoCliente modeloVisualizaçãoCliente)
        {
            var response = await _clienteClient.Excluir(modeloVisualizaçãoCliente.ClienteId);

            if (response.IsSuccessStatusCode)
            {
                TempData["MemsagemDeSucesso"] = "A remoção foi efetuada com salva com sucesso !";
                return RedirectToAction("Listagem", "Cliente");
            }

            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var erroResult = await response.Content.ReadAsStringAsync();
            var erros = JsonSerializer.Deserialize<ValidationResult>(erroResult, option);
            ViewBag.Erros = erros.Errors.Select(x => x.ErrorMessage).ToList();
            ViewBag.PodeAtualizar = HttpContext.User.HasClaim("Permissões", "Cliente.Atualizar");

            return View(modeloVisualizaçãoCliente);
        }
    }
}
