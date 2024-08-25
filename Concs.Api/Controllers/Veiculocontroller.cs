using Concs.Dominio.Interfaces;
using Concs.Dominio.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Concs.Api.Controllers
{

    public class Veiculocontroller : ControladorBase
    {
        private readonly IServiçoVeiculo _serviçoVeiculo;

        public Veiculocontroller(IServiçoVeiculo serviçoVeiculo)
        {
            _serviçoVeiculo = serviçoVeiculo;
        }

        [HttpGet]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Client)]
        public ActionResult<ModeloConsultaVeiculo> Todos()
        {
            return RespostaCustomizada(_serviçoVeiculo.FindAll());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ModeloVisualizaçãoVeiculo>> Encontrar([FromRoute] int id)
        {
            return RespostaCustomizada(await _serviçoVeiculo.FindById(id));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Inserir([FromBody] ModeloInserçãoVeiculo modelo)
        {
            return RespostaCustomizada(await _serviçoVeiculo.Insert(modelo));
        }

        [HttpPut]
        public async Task<ActionResult<int>> Atualizar([FromBody] ModeloAtualizaçãoVeiculo modelo)
        {
            return RespostaCustomizada(await _serviçoVeiculo.Update(modelo));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<int>> Excluir([FromRoute] int id)
        {
            return RespostaCustomizada(await _serviçoVeiculo.Remove(id));
        }
    }
}
