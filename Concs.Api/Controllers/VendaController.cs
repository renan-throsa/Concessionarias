using Concs.Api.Controllers;
using Concs.Dominio.Interfaces;
using Concs.Dominio.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Venda.API.Controllers
{

    public class VendaController : ControladorBase
    {
        private readonly IServiçoVenda _serviçoVenda;

        public VendaController(IServiçoVenda serviçoVenda)
        {
            _serviçoVenda = serviçoVenda;
        }

        [HttpGet]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Client)]
        public ActionResult<ModeloConsultaVenda> Todos()
        {
            return RespostaCustomizada(_serviçoVenda.FindAll());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ModeloVisualizaçãoVenda>> Encontrar([FromRoute] int id)
        {
            return RespostaCustomizada(await _serviçoVenda.FindById(id));
        }

        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Client)]
        [HttpGet(nameof(Relatorios))]
        public async Task<ActionResult<int>> Relatorios([FromQuery] int mes, int ano)
        {
            return RespostaCustomizada(await _serviçoVenda.Relatorios(mes, ano));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<int>> Atualizar([FromRoute] int id)
        {
            return RespostaCustomizada(await _serviçoVenda.Remove(id));
        }


    }
}
