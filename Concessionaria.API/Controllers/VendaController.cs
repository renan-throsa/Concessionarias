using Concessionarias.API.Controllers;
using Concessionarias.Dominio.Interfaces;
using Concessionarias.Dominio.Modelos;
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

        [HttpGet($"{nameof(Todos)}")]
        public ActionResult<ModeloConsultaVenda> Todos()
        {
            return RespostaCustomizada(_serviçoVenda.FindAll());
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

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<int>> Atualizar([FromRoute] int id)
        {
            return RespostaCustomizada(await _serviçoVenda.Remove(id));
        }
    }
}
