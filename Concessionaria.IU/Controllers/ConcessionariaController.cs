using Concessionarias.Dominio.Modelos;
using Concessionarias.IU.Clients;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Concessionarias.IU.Controllers
{
    public class ConcessionariaController : Controller
    {
        private readonly IConcessionariaClient _concessionariaClient;

        public ConcessionariaController(IConcessionariaClient ConcessionariaClient)
        {
            _concessionariaClient = ConcessionariaClient;
        }

        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public async Task<ActionResult> Listagem()
        {
            var vm = await _concessionariaClient.Listagem();
            return View(vm);
        }

        public ActionResult Criar()
        {
            ViewBag.Erros = new List<string>();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Criar(ModeloInserçãoConcessionária modeloInserçãoConcessionaria)
        {
            var response = await _concessionariaClient.Inserir(modeloInserçãoConcessionaria);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Listagem", "Concessionaria");
            }

            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var result = await response.Content.ReadAsStringAsync();
            var erro = JsonSerializer.Deserialize<ValidationResult>(result, option);

            ViewBag.Erros = erro.Errors.Select(x => x.ErrorMessage).ToList();

            return View(modeloInserçãoConcessionaria);
        }


        [HttpGet]
        public async Task<ActionResult> Editar(int id)
        {
            var response = await _concessionariaClient.Encontrar(id);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var model = JsonSerializer.Deserialize<ModeloAtualizaçãoConcessionária>(result, option);
                return View(model);
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(ModeloAtualizaçãoConcessionária modeloAtualizaçãoConcessionaria)
        {
            var response = await _concessionariaClient.Atualizar(modeloAtualizaçãoConcessionaria);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Listagem", "Concessionaria");
            }

            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var result = await response.Content.ReadAsStringAsync();
            var erros = JsonSerializer.Deserialize<ValidationResult>(result, option);

            ViewBag.Erros = erros.Errors.Select(x => x.ErrorMessage);


            return View(modeloAtualizaçãoConcessionaria);
        }
    }
}
