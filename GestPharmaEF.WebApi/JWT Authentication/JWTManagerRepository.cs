using GestPharmaEF.WebApi.JWT_Authentication.JWTWebAuthentication.Repository;
using GestPharmaEF.WebApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GestPharmaEF.DAL.Repositories;
using GestPharmaEF.DAL.Entities;
using GestPharmaEF.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GestPharmaEF.WebApi.JWT_Authentication
{
	public class JWTManagerRepository : IJWTManagerRepository
	{
        public JWTManagerRepository()
        {

        }
        public Tokens Authenticate(J_Users users)
		{

			JwtSecurityTokenHandler tokenHandler = new();
			//var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
			byte[] tokenKey = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRETJWT_GestPharmaEF", EnvironmentVariableTarget.Machine)??string.Empty);

            SecurityToken token = new JwtSecurityToken(null, null, new Claim[]
                       {
                          new Claim(ClaimTypes.Name, users.Email??String.Empty),
                          new Claim(ClaimTypes.Role, users.Role??String.Empty)
                       }, DateTime.Now, DateTime.Now.AddDays(1), new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature));
            return new Tokens { Token = tokenHandler.WriteToken(token) };

		}
	}
}
