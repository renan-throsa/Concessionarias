using Concs.Dominio.Interfaces;
using Concs.Dominio.Modelos;
using Concs.Negocio.Seviços;
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
        public async Task <ActionResult<IEnumerable<ModeloVisualizaçãoFabricante>>> Todos()
        {
            var chave = "ChaveListagemFabricantes";
            var opereçãoListagem = await _cacheamento.ObtertAsync(chave);

            if (!string.IsNullOrEmpty(opereçãoListagem))
            {
                return Ok(opereçãoListagem);
            }
            else
            {
                var operaçãoListagem = _serviçoFabricante.FindAll();
                return await RespostaCustomizada(operaçãoListagem, chave);
            }
           
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ModeloVisualizaçãoFabricante>> Encontrar([FromRoute] int id)
        {
            return RespostaCustomizada(await _serviçoFabricante.FindById(id));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Inserir([FromBody] ModeloInserçãoFabricante modelo)
        {
            return RespostaCustomizada(await _serviçoFabricante.Insert(modelo));
        }

        [HttpPut]
        public async Task<ActionResult<int>> Atualizar([FromBody] ModeloAtualizaçãoFabricante modelo)
        {
            return RespostaCustomizada(await _serviçoFabricante.Update(modelo));
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<int>> Atualizar([FromRoute] int id)
        {
            return RespostaCustomizada(await _serviçoFabricante.Remove(id));
        }
        
    }
}
