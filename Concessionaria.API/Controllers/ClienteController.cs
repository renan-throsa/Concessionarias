

using Concessionaria.Dominio.Interfaces;
using Concessionaria.Dominio.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Concessionaria.API.Controllers
{
    public class ClienteController : ControladorBase
    {
        private readonly IServiçoCliente _serviçoCliente;

        public ClienteController(IServiçoCliente serviçoCliente)
        {
            _serviçoCliente = serviçoCliente;
        }

        [HttpGet($"{nameof(Todos)}")]
        public ActionResult<ModeloVisualizaçãoCliente> Todos()
        {
            var response = _serviçoCliente.FindAll();
            return Ok(response.Content);
        }
    }
}
