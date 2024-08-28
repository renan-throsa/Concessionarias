using Concs.Dominio;
using Concs.Dominio.Interfaces;
using Concs.Dominio.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Concs.Api.Controllers
{

    public class Veiculocontroller : ControladorBase
    {
        private readonly IServiçoVeiculo _serviçoVeiculo;

        public Veiculocontroller(IServiçoVeiculo serviçoVeiculo, ICacheamento cacheamento) : base(cacheamento)
        {
            _serviçoVeiculo = serviçoVeiculo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModeloConsultaVeiculo>>> Todos()
        {
            var opereçãoListagem = await _cacheamento.ObtertAsync(Constantes.CHAVELISTAGEMVEICULOS);

            if (!string.IsNullOrEmpty(opereçãoListagem))
            {
                return Ok(opereçãoListagem);
            }
            else
            {
                var operaçãoListagem = _serviçoVeiculo.FindAll();
                return await RespostaCustomizada(operaçãoListagem, Constantes.CHAVELISTAGEMVEICULOS);
            }
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
