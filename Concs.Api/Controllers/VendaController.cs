using Concs.Dominio;
using Concs.Dominio.Interfaces;
using Concs.Dominio.Modelos;
using Concs.Negocio.Seviços;
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
        public async Task<ActionResult<IEnumerable<ModeloConsultaVenda>>> Todos()
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
        public async Task<ActionResult<ModeloVisualizaçãoVenda>> Encontrar([FromRoute] int id)
        {
            return RespostaCustomizada(await _serviçoVenda.FindById(id));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Inserir([FromBody] ModeloInserçãoVenda modelo)
        {
            return RespostaCustomizada(await _serviçoVenda.Insert(modelo));
        }

        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Client)]
        [HttpGet(nameof(Relatorios))]
        public async Task<ActionResult<int>> Relatorios([FromQuery] int mes, int ano)
        {
            return RespostaCustomizada(await _serviçoVenda.Relatorios(mes, ano));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<int>> Excluir([FromRoute] int id)
        {
            return RespostaCustomizada(await _serviçoVenda.Remove(id));
        }


    }
}
