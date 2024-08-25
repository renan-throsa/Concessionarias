using Concessionarias.Dominio.Interfaces;
using Concessionarias.Dominio.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Concessionarias.API.Controllers
{

    public class ConcessionariaController : ControladorBase
    {
        private readonly IServiçoConcessionária _serviçoConcessionaria;

        public ConcessionariaController(IServiçoConcessionária serviçoConcessionaria)
        {
            _serviçoConcessionaria = serviçoConcessionaria;
        }

        [HttpGet]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Client)]
        public ActionResult<ModeloVisualizaçãoConcessionária> Todos()
        {
            return RespostaCustomizada(_serviçoConcessionaria.FindAll());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ModeloVisualizaçãoConcessionária>> Encontrar([FromRoute] int id)
        {
            return RespostaCustomizada(await _serviçoConcessionaria.FindById(id));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Inserir([FromBody] ModeloInserçãoConcessionária modelo)
        {
            return RespostaCustomizada(await _serviçoConcessionaria.Insert(modelo));
        }

        [HttpPut]
        public async Task<ActionResult<int>> Atualizar([FromBody] ModeloAtualizaçãoConcessionária modelo)
        {
            return RespostaCustomizada(await _serviçoConcessionaria.Update(modelo));
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<int>> Atualizar([FromRoute] int id)
        {
            return RespostaCustomizada(await _serviçoConcessionaria.Remove(id));
        }
    }
}
