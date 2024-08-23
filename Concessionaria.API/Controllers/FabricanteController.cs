using Concessionarias.Dominio.Interfaces;
using Concessionarias.Dominio.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Concessionarias.API.Controllers
{

    public class FabricanteController : ControladorBase
    {
        private readonly IServiçoFabricante _serviçoFabricante;

        public FabricanteController(IServiçoFabricante serviçoFabricante)
        {
            _serviçoFabricante = serviçoFabricante;
        }

        [HttpGet($"{nameof(Todos)}")]
        public ActionResult<ModeloVisualizaçãoFabricante> Todos()
        {
            return RespostaCustomizada(_serviçoFabricante.FindAll());
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
