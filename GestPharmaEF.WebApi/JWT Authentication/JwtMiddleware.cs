using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestPharmaEF.WebApi.JWT_Authentication
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            StringValues values = context.Request.Headers.FirstOrDefault(h => h.Key == "Authorization").Value;
            string? token = values.FirstOrDefault(v => v.StartsWith("Bearer "))?.Replace("Bearer ", string.Empty);

            if(token != null)
            {
                byte[] macle = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRETJWT_GestPharmaEF", EnvironmentVariableTarget.Machine) ?? "");
                JwtSecurityTokenHandler handler = new ();
                ClaimsPrincipal c = handler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = false,                                     // qui m'a donner le token
                    ValidateAudience = false,                                   // pourquoi j'en ai besoin (domaine cad les API a joindre)
                    ValidateLifetime = false,                                   // durée
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(macle)          // pour une mutuelle validation entre client et serveur.
                }, out SecurityToken st);
                context.User = c;
            }
            await _next.Invoke(context);
        }
    }
}
