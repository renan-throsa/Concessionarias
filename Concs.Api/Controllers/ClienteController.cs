

using Concs.Dominio.Interfaces;
using Concs.Dominio.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Concs.Api.Controllers
{
    public class ClienteController : ControladorBase
    {
        private readonly IServiçoCliente _serviçoCliente;

        public ClienteController(IServiçoCliente serviçoCliente)
        {
            _serviçoCliente = serviçoCliente;
        }

        [HttpGet]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Client)]
        public ActionResult<ModeloVisualizaçãoCliente> Todos()
        {
            return RespostaCustomizada(_serviçoCliente.FindAll());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ModeloVisualizaçãoCliente>> Encontrar([FromRoute] int id)
        {
            return RespostaCustomizada(await _serviçoCliente.FindById(id));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Inserir([FromBody] ModeloInserçãoCliente modelo)
        {
            return RespostaCustomizada(await _serviçoCliente.Insert(modelo));
        }

        [HttpPut]
        public async Task<ActionResult<int>> Atualizar([FromBody] ModeloAtualizaçãoCliente modelo)
        {
            return RespostaCustomizada(await _serviçoCliente.Update(modelo));
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<int>> Atualizar([FromRoute] int id)
        {
            return RespostaCustomizada(await _serviçoCliente.Remove(id));
        }
        
    }
}
