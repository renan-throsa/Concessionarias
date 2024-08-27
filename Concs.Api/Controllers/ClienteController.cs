using Concs.Dominio.Interfaces;
using Concs.Dominio.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Concs.Api.Controllers
{
    public class ClienteController : ControladorBase
    {
        private readonly IServiçoCliente _serviçoCliente;

        public ClienteController(IServiçoCliente serviçoCliente, ICacheamento cacheamento) : base(cacheamento)
        {
            _serviçoCliente = serviçoCliente;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModeloVisualizaçãoCliente>>> Todos()
        {
            var chave = "ChaveListagemClientes";
            var opereçãoListagem = await _cacheamento.ObtertAsync(chave);

            if (!string.IsNullOrEmpty(opereçãoListagem))
            {
                return Ok(opereçãoListagem);
            }
            else
            {
                var operaçãoListagem = _serviçoCliente.FindAll();
                return await RespostaCustomizada(operaçãoListagem, chave);
            }

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
