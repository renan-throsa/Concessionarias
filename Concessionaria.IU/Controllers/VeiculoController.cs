using Concessionarias.Dominio.Modelos;
using Concessionarias.IU.Clientes;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

namespace Concessionarias.IU.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly IVeiculoClient _veiculoClient;
        private readonly IFabricanteClient _fabricanteClient;
        public VeiculoController(IVeiculoClient VeiculoClient, IFabricanteClient fabricanteClient)
        {
            _veiculoClient = VeiculoClient;
            _fabricanteClient = fabricanteClient;
        }

        public async Task<ActionResult> Listagem()
        {
            var vm = await _veiculoClient.Listagem();
            return View(vm);
        }

        public async Task<ActionResult> Criar()
        {
            ViewBag.Fabricantes = (await _fabricanteClient.Listagem()).Select(x => new SelectListItem() { Value = x.FabricanteId.ToString(), Text = x.Nome }).ToList();
            ViewBag.Erros = new List<string>();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Criar(ModeloInserçãoVeiculo  modeloInserçãoVeiculo)
        {
            var response = await _veiculoClient.Inserir(modeloInserçãoVeiculo);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Listagem", "Veiculo");
            }

            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var result = await response.Content.ReadAsStringAsync();
            var erro = JsonSerializer.Deserialize<ValidationResult>(result, option);

            ViewBag.Fabricantes = (await _fabricanteClient.Listagem()).Select(x => new SelectListItem() { Value = x.FabricanteId.ToString(), Text = x.Nome }).ToList();
            ViewBag.Erros = erro.Errors.Select(x => x.ErrorMessage).ToList();

            return View(modeloInserçãoVeiculo);
        }


        [HttpGet]
        public async Task<ActionResult> Editar(int id)
        {
            var response = await _veiculoClient.Encontrar(id);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var model = JsonSerializer.Deserialize<ModeloAtualizaçãoVeiculo>(result, option);

                ViewBag.Erros = new List<string>();
                ViewBag.Fabricantes = (await _fabricanteClient.Listagem()).Select(x => new SelectListItem() { Value = x.FabricanteId.ToString(), Text = x.Nome }).ToList();

                return View(model);
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(ModeloAtualizaçãoVeiculo  modeloAtualizaçãoVeiculo)
        {
            var response = await _veiculoClient.Atualizar(modeloAtualizaçãoVeiculo);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Listagem", "Veiculo");
            }

            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var result = await response.Content.ReadAsStringAsync();
            var erros = JsonSerializer.Deserialize<ValidationResult>(result, option);

            ViewBag.Fabricantes = (await _fabricanteClient.Listagem()).Select(x => new SelectListItem() { Value = x.FabricanteId.ToString(), Text = x.Nome }).ToList();
            ViewBag.Erros = erros.Errors.Select(x => x.ErrorMessage).ToList();


            return View(modeloAtualizaçãoVeiculo);
        }
    }
}
