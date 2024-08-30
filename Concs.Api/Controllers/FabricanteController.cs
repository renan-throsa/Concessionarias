using Concs.Api.Filtros;
using Concs.Dominio;
using Concs.Dominio.Interfaces;
using Concs.Dominio.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Concs.Api.Controllers
{

    public class FabricanteController : ControladorBase
    {
        private readonly IServiçoFabricante _serviçoFabricante;

        public FabricanteController(IServiçoFabricante serviçoFabricante, ICacheamento cacheamento) : base(cacheamento)
        {
            _serviçoFabricante = serviçoFabricante;
        }

        [HttpGet]
        [Authorization(Claim: "Fabricante.Ler")]
        public async Task <ActionResult<IEnumerable<ModeloVisualizaçãoFabricante>>> Ler()
        {
            var opereçãoListagem = await _cacheamento.ObtertAsync(Constantes.CHAVELISTAGEMFABRICANTES);

            if (!string.IsNullOrEmpty(opereçãoListagem))
            {
                return Ok(opereçãoListagem);
            }
            else
            {
                var operaçãoListagem = _serviçoFabricante.FindAll();
                return await RespostaCustomizada(operaçãoListagem, Constantes.CHAVELISTAGEMFABRICANTES);
            }
           
        }

        [HttpGet("{id:int}")]
        [Authorization(Claim: "Fabricante.Ler")]
        public async Task<ActionResult<ModeloVisualizaçãoFabricante>> Ler([FromRoute] int id)
        {
            return RespostaCustomizada(await _serviçoFabricante.FindById(id));
        }

        [HttpPost]
        [Authorization(Claim: "Fabricante.Inserir")]
        public async Task<ActionResult<int>> Inserir([FromBody] ModeloInserçãoFabricante modelo)
        {
            return RespostaCustomizada(await _serviçoFabricante.Insert(modelo));
        }

        [HttpPut]
        [Authorization(Claim: "Fabricante.Atualizar")]
        public async Task<ActionResult<int>> Atualizar([FromBody] ModeloAtualizaçãoFabricante modelo)
        {
            return RespostaCustomizada(await _serviçoFabricante.Update(modelo));
        }


        [HttpDelete("{id:int}")]
        [Authorization(Claim: "Fabricante.Atualizar")]
        public async Task<ActionResult<int>> Excluir([FromRoute] int id)
        {
            return RespostaCustomizada(await _serviçoFabricante.Remove(id));
        }
        
    }
}
