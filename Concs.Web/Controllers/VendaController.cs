﻿using Concs.Dominio.Modelos;
using Concs.App.Clients;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

namespace Concs.App.Controllers
{
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
            return View(vm);
        }

        public async Task<ActionResult> Criar()
        {
            ViewBag.Veiculos = (await _veiculoClient.Listagem()).Select(x => new SelectListItem() { Text = x.Resumo, Value = x.VeiculoId.ToString() }).ToList();
            ViewBag.Concs = (await _concessionariaClient.Listagem()).Select(x => new SelectListItem() { Text = x.Resumo, Value = x.ConcessionariaId.ToString() }).ToList();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Criar(ModeloInserçãoVenda modeloInserçãoVenda)
        {
            var response = await _vendaClient.Inserir(modeloInserçãoVenda);

            if (response.IsSuccessStatusCode)
            {
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
        public async Task<ActionResult> Visualizar(int id)
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
                                

                return View(model);
            }
            return View();
        }
    }
}
