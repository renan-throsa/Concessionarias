using Concessionarias.Dominio.Modelos;
using Concessionarias.IU.Clientes;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Concessionarias.IU.Controllers
{
    public class FabricanteController : Controller
    {
        private readonly IFabricanteClient _fabricanteClient;

        public FabricanteController(IFabricanteClient fabricanteClient)
        {
            _fabricanteClient = fabricanteClient;
        }

        public async Task<ActionResult> Listagem()
        {
            var vm = await _fabricanteClient.Listagem();
            return View(vm);
        }

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

                var model = JsonSerializer.Deserialize<ModeloVisualizaçãoFabricante>(result, option);
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

            ViewBag.Erros = erros.Errors.Select(x => x.ErrorMessage);


            return View(modeloAtualizaçãoFabricante);
        }
    }
}
