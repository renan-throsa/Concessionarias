using Concs.Dominio.Modelos;
using Concs.App.Clients;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace Concs.App.Controllers
{
    [Authorize]
    public class FabricanteController : Controller
    {
        private readonly IFabricanteClient _fabricanteClient;

        public FabricanteController(IFabricanteClient fabricanteClient)
        {
            _fabricanteClient = fabricanteClient;
        }

        [HttpGet]
        public async Task<ActionResult> Listagem()
        {
            var vm = await _fabricanteClient.Listagem();
            ViewBag.PodeInserir = HttpContext.User.HasClaim("Permissões", "Fabricante.Inserir");
            ViewBag.PodeAtualizar = HttpContext.User.HasClaim("Permissões", "Fabricante.Atualizar");
            return View(vm);
        }

        [HttpGet]
        public ActionResult Criar()
        {
            ViewBag.Erros = new List<string>();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Criar(ModeloInserçãoFabricante modeloInserçãoFabricante)
        {
            var response = await _fabricanteClient.Inserir(modeloInserçãoFabricante);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Listagem", "Fabricante");
            }

            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var result = await response.Content.ReadAsStringAsync();
            var erro = JsonSerializer.Deserialize<ValidationResult>(result, option);

            ViewBag.Erros = erro.Errors.Select(x => x.ErrorMessage).ToList();

            return View(modeloInserçãoFabricante);
        }


        [HttpGet]
        public async Task<ActionResult> Editar(int id)
        {
            var response = await _fabricanteClient.Encontrar(id);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var model = JsonSerializer.Deserialize<ModeloAtualizaçãoFabricante>(result, option);
                return View(model);
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(ModeloAtualizaçãoFabricante modeloAtualizaçãoFabricante)
        {
            var response = await _fabricanteClient.Atualizar(modeloAtualizaçãoFabricante);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Listagem", "Fabricante");
            }

            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var result = await response.Content.ReadAsStringAsync();
            var erros = JsonSerializer.Deserialize<ValidationResult>(result, option);

            ViewBag.Erros = erros.Errors.Select(x => x.ErrorMessage).ToList();


            return View(modeloAtualizaçãoFabricante);
        }


        [HttpGet]
        public async Task<ActionResult> Detalhes(int id)
        {
            var response = await _fabricanteClient.Encontrar(id);
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            if (response.IsSuccessStatusCode)
            {
                var sucssesResult = await response.Content.ReadAsStringAsync();

                var model = JsonSerializer.Deserialize<ModeloVisualizaçãoFabricante>(sucssesResult, option);

                ViewBag.Erros = new List<string>();
                ViewBag.PodeAtualizar = HttpContext.User.HasClaim("Permissões", "Fabricante.Atualizar");
                return View(model);
            }


            var erroResult = await response.Content.ReadAsStringAsync();
            var erros = JsonSerializer.Deserialize<ValidationResult>(erroResult, option);

            ViewBag.Erros = erros.Errors.Select(x => x.ErrorMessage).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Detalhes(ModeloVisualizaçãoFabricante modeloVisualizaçãoFabricante)
        {
            var response = await _fabricanteClient.Excluir(modeloVisualizaçãoFabricante.FabricanteId);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Listagem", "Fabricante");
            }

            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var erroResult = await response.Content.ReadAsStringAsync();
            var erros = JsonSerializer.Deserialize<ValidationResult>(erroResult, option);

            ViewBag.Erros = erros.Errors.Select(x => x.ErrorMessage).ToList();

            return View(modeloVisualizaçãoFabricante);
        }
    }
}
