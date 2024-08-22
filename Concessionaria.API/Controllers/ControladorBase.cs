using Concessionaria.Dominio.Modelos;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Concessionaria.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControladorBase : ControllerBase
    {
        protected ActionResult<ModeloResultadoDaOperação> ErrorResponse(ModeloResultadoDaOperação result)
        {
            switch (result.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    return BadRequest(result);

                case HttpStatusCode.NotFound:
                    return NotFound(result);

                case HttpStatusCode.Unauthorized:
                    return Unauthorized(result);

                case HttpStatusCode.Conflict:
                    return Conflict(result);

                default:
                    return BadRequest(result);
            }
        }
    }
}
