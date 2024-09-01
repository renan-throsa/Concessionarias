using Concs.Dominio.Modelos;
using Concs.App.Clients;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace Concs.App.Controllers
{
    [Authorize]
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
            ViewBag.PodeInserir = HttpContext.User.HasClaim("Permissões", "Concessionária.Inserir");
            ViewBag.PodeAtualizar = HttpContext.User.HasClaim("Permissões", "Concessionária.Atualizar");
            return View(vm);
        }

        public ActionResult Criar()
        {
            ViewBag.Erros = new List<string>();
            return View();
        }


        [HttpPost]
        
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
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            if (response.IsSuccessStatusCode)
            {
                var sucssesResult = await response.Content.ReadAsStringAsync();             

                var model = JsonSerializer.Deserialize<ModeloAtualizaçãoConcessionária>(sucssesResult, option);
                return View(model);
            }

            var erroResult = await response.Content.ReadAsStringAsync();
            var erros = JsonSerializer.Deserialize<ValidationResult>(erroResult, option);

            ViewBag.Erros = erros.Errors.Select(x => x.ErrorMessage).ToList();
            return View();
        }


        [HttpPost]
        
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

            ViewBag.Erros = erros.Errors.Select(x => x.ErrorMessage).ToList();


            return View(modeloAtualizaçãoConcessionaria);
        }

        [HttpGet]
        public async Task<ActionResult> Detalhes(int id)
        {
            var response = await _concessionariaClient.Encontrar(id);
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            if (response.IsSuccessStatusCode)
            {
                var sucssesResult = await response.Content.ReadAsStringAsync();

                var model = JsonSerializer.Deserialize<ModeloVisualizaçãoConcessionária>(sucssesResult, option);

                ViewBag.Erros = new List<string>();
                ViewBag.PodeAtualizar = HttpContext.User.HasClaim("Permissões", "Concessionária.Atualizar");
                return View(model);
            }


            var erroResult = await response.Content.ReadAsStringAsync();
            var erros = JsonSerializer.Deserialize<ValidationResult>(erroResult, option);

            ViewBag.Erros = erros.Errors.Select(x => x.ErrorMessage).ToList();
            return View();
        }
    }
}
