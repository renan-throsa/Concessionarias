using Concs.Dominio.Interfaces;
using Concs.Dominio.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Concs.Api.Controllers
{

    public class UsuarioController : ControladorBase
    {
        private readonly IServiçoUsuario _serviçoUsuario;

        public UsuarioController(IServiçoUsuario serviçoUsuario)
        {
            _serviçoUsuario = serviçoUsuario;
        }

        [HttpPost(nameof(Registrar))]
        public async Task<ActionResult<string>> Registrar(ModeloRegistroUsuario modeloInserçãoUsuario)
        {
            return RespostaCustomizada(await _serviçoUsuario.Registrar(modeloInserçãoUsuario));
        }

        [HttpPost(nameof(Autenticar))]
        public async Task<ActionResult<string>> Autenticar(ModeloAutencicaçãoUsuario modeloConsultaUsuario)
        {
            return RespostaCustomizada(await _serviçoUsuario.Autenticar(modeloConsultaUsuario));
        }


    }
}
