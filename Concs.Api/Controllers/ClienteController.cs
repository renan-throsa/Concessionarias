using Concs.Api.Filtros;
using Concs.Dominio;
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
        [Authorization(Claim: "Cliente.Ler")]
        public async Task<ActionResult<IEnumerable<ModeloVisualizaçãoCliente>>> Ler()
        {
            var opereçãoListagem = await _cacheamento.ObtertAsync(Constantes.CHAVELISTAGEMCLIENTES);

            if (!string.IsNullOrEmpty(opereçãoListagem))
            {
                return Ok(opereçãoListagem);
            }
            else
            {
                var operaçãoListagem = _serviçoCliente.FindAll();
                return await RespostaCustomizada(operaçãoListagem, Constantes.CHAVELISTAGEMCLIENTES);
            }

        }

        [HttpGet("{id:int}")]
        [Authorization(Claim: "Cliente.Ler")]
        public async Task<ActionResult<ModeloVisualizaçãoCliente>> Ler([FromRoute] int id)
        {
            return RespostaCustomizada(await _serviçoCliente.FindById(id));
        }

        [HttpPost]
        [Authorization(Claim: "Cliente.Inserir")]
        public async Task<ActionResult<int>> Inserir([FromBody] ModeloInserçãoCliente modelo)
        {
            return RespostaCustomizada(await _serviçoCliente.Insert(modelo));
        }

        [HttpPut]
        [Authorization(Claim: "Cliente.Atualizar")]
        public async Task<ActionResult<int>> Atualizar([FromBody] ModeloAtualizaçãoCliente modelo)
        {
            return RespostaCustomizada(await _serviçoCliente.Update(modelo));
        }


        [HttpDelete("{id:int}")]
        [Authorization(Claim: "Cliente.Atualizar")]
        public async Task<ActionResult<int>> Atualizar([FromRoute] int id)
        {
            return RespostaCustomizada(await _serviçoCliente.Remove(id));
        }

    }
}
