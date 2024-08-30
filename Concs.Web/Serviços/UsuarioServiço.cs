using Concs.Web.Models;
using System.Collections.Immutable;
using System.IdentityModel.Tokens.Jwt;


namespace Concs.Web.Serviços
{
    public interface IUsuarioServiço
    {
        public void GuardarUsuario(string token);
        public void ApagarUsuario();
        public ModeloUsuario ObterUsuario();
        public string ObterToken();
        public bool UsuarioValido();
        public bool TemPermissão(string permissão);

    }

    public class UsuarioServiço : IUsuarioServiço
    {
        private ModeloUsuario _usuario;

        public UsuarioServiço()
        {
            _usuario = new ModeloUsuario();
        }
        public void ApagarUsuario()
        {
            _usuario = new ModeloUsuario();
        }

        public void GuardarUsuario(string token)
        {
            var resultado = new JwtSecurityToken(jwtEncodedString: token);
            _usuario = new ModeloUsuario
            {
                Id = resultado.Id,
                Nome = resultado.Claims.First(c => c.Type == "name").Value,
                Email = resultado.Claims.First(c => c.Type == "email").Value,
                Permissões = resultado.Claims.Where(c => c.Type == "Permissões").Select(x => x.Value).ToImmutableList(),
                Token = token
            };
        }

        public string ObterToken()
        {
            return $"Bearer {_usuario.Token}";
        }

        public ModeloUsuario ObterUsuario()
        {
            return _usuario;
        }

        public bool TemPermissão(string permissão)
        {
            return _usuario.Permissões.Any(x => x.Equals(permissão));
        }

        public bool UsuarioValido()
        {
            return _usuario.Valido;
        }
    }
}
