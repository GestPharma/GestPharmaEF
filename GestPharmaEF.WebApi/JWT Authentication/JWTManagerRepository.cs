using GestPharmaEF.Models.Concretes;
using GestPharmaEF.WebApi.JWT_Authentication.JWTWebAuthentication.Repository;
using GestPharmaEF.WebApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;

namespace GestPharmaEF.WebApi.JWT_Authentication
{
	public class JWTManagerRepository : IJWTManagerRepository
	{
		Dictionary<string, string> UsersRecords = new();

		private readonly IConfiguration iconfiguration;
		public JWTManagerRepository(IConfiguration iconfiguration)
		{
			this.iconfiguration = iconfiguration;
			UsersRecords = new();
			DAL.Repositories.PersonneRepository personneRepository = new();
			foreach (Personnes perso in personneRepository.GetAll())
			{
				UsersRecords.Add(perso.email, perso.paswword);
			}
		}

		public Tokens Authenticate(J_Users users)
		{

			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
			//var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
			byte[] tokenKey = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRETJWT_GestPharmaEF", EnvironmentVariableTarget.Machine));

			Personnes u1 = new (users.email, users.paswword, true, 2);
			u1.Id = 0;
			DAL.Repositories.PersonneRepository personneRepository = new();
			foreach (Personnes perso in personneRepository.GetAll())
			{
				if ((perso.email == users.email) && (perso.paswword == users.paswword)) u1 = perso;
			}
			if (u1.Id==0) return null;

			DAL.Repositories.RoleRepository roleRepository = new();
			SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
			  {
				 new Claim(ClaimTypes.Name, users.email),
				 new Claim(ClaimTypes.Role, roleRepository.GetOne(u1.currentrole).Name)
			  }),
				Expires = DateTime.UtcNow.AddMinutes(59),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
			};
			SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
			return new Tokens { Token = tokenHandler.WriteToken(token) };

		}
		public static string EncriptaPassWord(string Password)
		{
			try
			{
				SHA256Managed hasher = new();

				byte[] pwdBytes = new UTF8Encoding().GetBytes(Password);
				byte[] keyBytes = hasher.ComputeHash(pwdBytes);

				hasher.Dispose();
				return Convert.ToBase64String(keyBytes);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}
		}

	}
}
