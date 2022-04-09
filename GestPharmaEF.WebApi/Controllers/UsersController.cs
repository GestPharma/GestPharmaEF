using GestPharmaEF.DAL.Repositories;
using GestPharmaEF.Models.Concretes;
using GestPharmaEF.WebApi.JWT_Authentication.JWTWebAuthentication.Repository;
using GestPharmaEF.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace GestPharmaEF.WebApi.Controllers
{
	[Authorize]
	[ApiController]
	[Route("api/[controller]")]

	public class UsersController : ControllerBase
	{
        private readonly IJWTManagerRepository _jWTManager;

		public UsersController(IJWTManagerRepository jWTManager)
		{
			this._jWTManager = jWTManager;
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public List<Personnes> Get()
		{
			PersonneRepository personneRepository = new();
			return new ObservableCollection<Personnes>(personneRepository.GetAll()).ToList();
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		[Route("authenticate")]
		public IActionResult Authenticate(J_Users usersdata)
		{
			var token = _jWTManager.Authenticate(usersdata);

			if (token == null)
			{
				return Unauthorized();
			}
			return Ok(token);
		}
	}
}
