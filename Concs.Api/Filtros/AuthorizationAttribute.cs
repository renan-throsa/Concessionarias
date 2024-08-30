using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Concs.Api.Filtros
{
    public class AuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _claim;

        public AuthorizationAttribute(string Claim) => _claim = Claim;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            ClaimsPrincipal? user = context.HttpContext.User;            

            var c = user.Claims.ToList();

            if (user.Identity.IsAuthenticated && user.HasClaim("Permissões", _claim))
            {
                return;
            }

            context.Result = new ForbidResult();

        }
    }
}
