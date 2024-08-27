using Concs.Dominio.Interfaces;
using Concs.Dominio.Modelos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace Concs.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControladorBase : ControllerBase
    {
        protected readonly ICacheamento _cacheamento;

        public ControladorBase(ICacheamento cacheamento)
        {
            _cacheamento = cacheamento;
        }

        protected async Task<ActionResult> RespostaCustomizada(ModeloResultadoDaOperação resultado, string chave)
        {

            if (!resultado.IsValid)
            {
                return ErrorResponse(resultado);
            }
            
            await _cacheamento.DefinirAsync(chave, JsonConvert.SerializeObject(resultado.Content, Formatting.Indented));
            return Ok(resultado.Content);
        }

        protected ActionResult RespostaCustomizada(ModeloResultadoDaOperação resultado)
        {

            if (!resultado.IsValid)
            {
                return ErrorResponse(resultado);
            }

            return Ok(resultado.Content);
        }

        protected ActionResult ErrorResponse(ModeloResultadoDaOperação resultado)
        {
            switch (resultado.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    return BadRequest(resultado.Result);

                case HttpStatusCode.NotFound:
                    return NotFound(resultado.Result);

                case HttpStatusCode.Unauthorized:
                    return Unauthorized(resultado.Result);

                case HttpStatusCode.Conflict:
                    return Conflict(resultado.Result);

                default:
                    return BadRequest(resultado.Result);
            }
        }
    }
}
