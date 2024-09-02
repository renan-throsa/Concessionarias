using Concs.Api.Filtros;
using Concs.Dominio;
using Concs.Dominio.Interfaces;
using Concs.Dominio.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Concs.Api.Controllers
{
    public class VendaController : ControladorBase
    {
        private readonly IServiçoVenda _serviçoVenda;

        public VendaController(IServiçoVenda serviçoVenda, ICacheamento cacheamento) : base(cacheamento)
        {
            _serviçoVenda = serviçoVenda;
        }

        [HttpGet]
        [Authorization(Claim: "Venda.Ler")]
        public async Task<ActionResult<IEnumerable<ModeloConsultaVenda>>> Ler()
        {
            var opereçãoListagem = await _cacheamento.ObtertAsync(Constantes.CHAVELISTAGEMVENDAS);

            if (!string.IsNullOrEmpty(opereçãoListagem))
            {
                return Ok(opereçãoListagem);
            }
            else
            {
                var operaçãoListagem = _serviçoVenda.FindAll();
                return await RespostaCustomizada(operaçãoListagem, Constantes.CHAVELISTAGEMVENDAS);
            }
        }

        [HttpGet("{id:int}")]
        [Authorization(Claim: "Venda.Ler")]
        public async Task<ActionResult<ModeloVisualizaçãoVenda>> Ler([FromRoute] int id)
        {
            return RespostaCustomizada(await _serviçoVenda.FindById(id));
        }

        [HttpPost]
        [Authorization(Claim: "Venda.Inserir")]
        public async Task<ActionResult<int>> Inserir([FromBody] ModeloInserçãoVenda modelo)
        {
            return RespostaCustomizada(await _serviçoVenda.Insert(modelo));
        }

        
        [HttpGet(nameof(Relatorios))]
        [Authorization(Claim: "Venda.Ler")]
        public async Task<ActionResult<int>> Relatorios([FromQuery] int mes, int ano)
        {
            return RespostaCustomizada(await _serviçoVenda.Relatorios(mes, ano));
        }

        [HttpDelete("{id:int}")]
        [Authorization(Claim: "Venda.Atualizar")]
        public async Task<ActionResult<int>> Excluir([FromRoute] int id)
        {
            return RespostaCustomizada(await _serviçoVenda.Remove(id));
        }


    }
}
