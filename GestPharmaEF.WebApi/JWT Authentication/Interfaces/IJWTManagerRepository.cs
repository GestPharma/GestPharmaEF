using GestPharmaEF.Models.Concretes;
using GestPharmaEF.WebApi.Models;

namespace GestPharmaEF.WebApi.JWT_Authentication.JWTWebAuthentication.Repository
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(J_Users users);
    }

}
