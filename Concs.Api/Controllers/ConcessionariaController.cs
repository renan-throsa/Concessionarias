using Concs.Dominio;
using Concs.Dominio.Interfaces;
using Concs.Dominio.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Concs.Api.Controllers
{

    public class ConcessionariaController : ControladorBase
    {
        private readonly IServiçoConcessionária _serviçoConcessionaria;

        public ConcessionariaController(IServiçoConcessionária serviçoConcessionaria, ICacheamento cacheamento) : base(cacheamento)
        {
            _serviçoConcessionaria = serviçoConcessionaria;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModeloVisualizaçãoConcessionária>>> Todos()
        {
            var opereçãoListagem = await _cacheamento.ObtertAsync(Constantes.CHAVELISTAGEMCONCESSIONARIAS);

            if (!string.IsNullOrEmpty(opereçãoListagem))
            {
                return Ok(opereçãoListagem);
            }
            else
            {
                var operaçãoListagem = _serviçoConcessionaria.FindAll();
                return await RespostaCustomizada(operaçãoListagem, Constantes.CHAVELISTAGEMCONCESSIONARIAS);
            }

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
