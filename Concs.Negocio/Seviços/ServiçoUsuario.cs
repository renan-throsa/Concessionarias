using Concs.Dominio.Interfaces;
using Concs.Dominio.Modelos;
using Concs.Negocio.Configs;
using Concs.Negocio.Validações;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Concs.Negocio.Seviços
{
    public class ServiçoUsuario : Serviço, IServiçoUsuario
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SegConfig _appSettings;
        protected readonly ILogger<IServiçoUsuario> _logger;

        public ServiçoUsuario(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IOptions<SegConfig> appSettings, ILogger<IServiçoUsuario> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _logger = logger;
        }

        public async Task<ModeloResultadoDaOperação> Autenticar(ModeloAutencicaçãoUsuario modeloAutencicaçãoUsuario)
        {
            _logger.LogInformation($"Logging sign in for: {modeloAutencicaçãoUsuario.Email}");

            if (!EntityIsValid(new ValidadorDeAutenticaçãoDeUsuario(), modeloAutencicaçãoUsuario))
                return Erro();

            var user = await _userManager.FindByEmailAsync(modeloAutencicaçãoUsuario.Email);

            if (user is null) return Erro($"Usuário {modeloAutencicaçãoUsuario.Email} não encontrado", HttpStatusCode.NotFound);

            var resultado = await _signInManager.PasswordSignInAsync(user, modeloAutencicaçãoUsuario.Senha, isPersistent: modeloAutencicaçãoUsuario.LembrasSe, lockoutOnFailure: true);
            if (resultado.IsLockedOut) return Erro($"Usuário bloquado por tentativas inválidas. Bloqueio temina às {user.LockoutEnd}", HttpStatusCode.BadRequest);
            if (!resultado.Succeeded) return Erro($"Usuário ou senha incorreto. Tentativas Restantes: {_appSettings.MaximoDeTentativasFalhas - user.AccessFailedCount}", HttpStatusCode.BadRequest);


            await _signInManager.SignInAsync(user, isPersistent: modeloAutencicaçãoUsuario.LembrasSe);
            return Successo(await ObterToken(user));
        }

        public Task<ModeloResultadoDaOperação> Registrar(ModeloRegistroUsuario modeloInserçãoUsuario)
        {
            throw new NotImplementedException();
        }

        private async Task<string> ObterToken(IdentityUser user)
        {

            var secretKey = Encoding.ASCII.GetBytes(_appSettings.Segredo);

            var claims = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, user.Id),
                    new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("name", user.UserName),

                });

            var permissoes = await _userManager.GetClaimsAsync(user);

            claims.AddClaims(permissoes);

            return new JwtSecurityTokenHandler().CreateEncodedJwt(
                new SecurityTokenDescriptor
                {
                    Issuer = _appSettings.Emissor,
                    Audience = _appSettings.Audiencia,
                    NotBefore = DateTime.Now,
                    Expires = DateTime.Now.AddHours(_appSettings.TempodeExpiraçãoEmHoras),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature),
                    Subject = claims
                });


        }

    }
}
