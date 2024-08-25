using Concessionarias.IU.Clients;
using Microsoft.AspNetCore.Mvc;

namespace Concessionarias.IU.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteClient _clienteClient;

        public ClienteController(IClienteClient clienteClient)
        {
            _clienteClient = clienteClient;
        }

        
        public async Task<ActionResult> Listagem()
        {
            var vm = await _clienteClient.Listagem();
            return View(vm);
        }
    }
}
