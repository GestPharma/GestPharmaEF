using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GestPharmaEF.WebApi.Filters
{
    [AttributeUsage(AttributeTargets.All)]
    public class AuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        public AuthorizationAttribute(params string[] authorizedRoles)
        {
            AuthorizedRoles = authorizedRoles;
        }

        private string[] AuthorizedRoles  { get; set; }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(AuthorizedRoles.Length == 0)
            {
                if(!(context.HttpContext.User.Identity?.IsAuthenticated ?? false))
                {
                    if (! context.HttpContext.Request.Path.StartsWithSegments("/api/Personnes/Login") &&
                        ! context.HttpContext.Request.Path.StartsWithSegments("/api/Personnes/Register") 
                        )
                    { 
                        context.Result = new UnauthorizedResult();
                    }
                }
            }
            else
            {
                if(!AuthorizedRoles.Any(r => context.HttpContext.User.IsInRole(r))) 
                {
                    context.Result = new UnauthorizedResult();
                }
            }
        }
    }
}
