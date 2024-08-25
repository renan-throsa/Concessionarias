using Concs.Dominio.Modelos;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Concs.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControladorBase : ControllerBase
    {
        protected ActionResult RespostaCustomizada(ModeloResultadoDaOperação resultado)
        {

            if (!resultado.IsValid)
            {
                return ErrorResponse(resultado);
            }

            return Ok(resultado.Content ?? string.Empty);
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
