using Concessionarias.Dominio.Modelos;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace Concessionarias.API.Controllers
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
                    return BadRequest(resultado);

                case HttpStatusCode.NotFound:
                    return NotFound(resultado);

                case HttpStatusCode.Unauthorized:
                    return Unauthorized(resultado);

                case HttpStatusCode.Conflict:
                    return Conflict(resultado);

                default:
                    return BadRequest(resultado);
            }
        }
    }
}
