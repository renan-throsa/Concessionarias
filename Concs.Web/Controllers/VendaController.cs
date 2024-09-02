using Concs.Dominio.Modelos;
using Concs.App.Clients;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace Concs.App.Controllers
{
    [Authorize]
    public class VendaController : Controller
    {
        private readonly IVeiculoClient _veiculoClient;
        private readonly IConcessionariaClient _concessionariaClient;
        private readonly IVendaClient _vendaClient;
        private readonly IClienteClient _clienteClient;
        

        public VendaController(IVendaClient vendaClient, IVeiculoClient VeiculoClient, IConcessionariaClient concessionariaClient, IClienteClient clienteClient)
        {
            _vendaClient = vendaClient;
            _veiculoClient = VeiculoClient;
            _concessionariaClient = concessionariaClient;
            _clienteClient = clienteClient;
        }

        
        public async Task<ActionResult> Listagem()
        {
            var vm = await _vendaClient.Listagem();
            ViewBag.PodeInserir = HttpContext.User.HasClaim("Permissões", "Venda.Inserir");
            return View(vm);
        }

        public async Task<ActionResult> Criar()
        {
            ViewBag.Veiculos = (await _veiculoClient.Listagem()).Select(x => new SelectListItem() { Text = x.Resumo, Value = x.VeiculoId.ToString() }).ToList();
            ViewBag.Concs = (await _concessionariaClient.Listagem()).Select(x => new SelectListItem() { Text = x.Resumo, Value = x.ConcessionariaId.ToString() }).ToList();
            return View();
        }


        [HttpPost]
        
        public async Task<ActionResult> Criar(ModeloInserçãoVenda modeloInserçãoVenda)
        {
            var response = await _vendaClient.Inserir(modeloInserçãoVenda);

            if (response.IsSuccessStatusCode)
            {
                TempData["MemsagemDeSucesso"] = "Nova venda registrada !";
                return RedirectToAction("Listagem", "Venda");
            }

            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var result = await response.Content.ReadAsStringAsync();
            var erro = JsonSerializer.Deserialize<ValidationResult>(result, option);

            ViewBag.Veiculos = (await _veiculoClient.Listagem()).Select(x => new SelectListItem() { Text = x.Resumo, Value = x.VeiculoId.ToString() }).ToList();
            ViewBag.Concs = (await _concessionariaClient.Listagem()).Select(x => new SelectListItem() { Text = x.Resumo, Value = x.ConcessionariaId.ToString() }).ToList();

            ViewBag.Erros = erro.Errors.Select(x => x.ErrorMessage).ToList();

            return View(modeloInserçãoVenda);
        }


        [HttpGet]
        public async Task<ActionResult> Detalhes(int id)
        {
            var response = await _vendaClient.Encontrar(id);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var model = JsonSerializer.Deserialize<ModeloVisualizaçãoVenda>(result, option);

                ViewBag.Erros = new List<string>();
                ViewBag.PodeAtualizar = HttpContext.User.HasClaim("Permissões", "Venda.Atualizar");
                return View(model);
            }
            return View();
        }

        [HttpPost]

        public async Task<ActionResult> Detalhes(ModeloVisualizaçãoVenda modeloVisualizaçãoVenda)
        {
            var response = await _vendaClient.Remover(modeloVisualizaçãoVenda.VendaId);

            if (response.IsSuccessStatusCode)
            {
                TempData["MemsagemDeSucesso"] = "A remoção foi efetuada com salva com sucesso !";
                return RedirectToAction("Listagem", "Venda");
            }

            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var erroResult = await response.Content.ReadAsStringAsync();
            var erros = JsonSerializer.Deserialize<ValidationResult>(erroResult, option);

            ViewBag.PodeAtualizar = HttpContext.User.HasClaim("Permissões", "Venda.Atualizar");
            ViewBag.Erros = erros.Errors.Select(x => x.ErrorMessage).ToList();

            return View(modeloVisualizaçãoVenda);
        }
    }
}
