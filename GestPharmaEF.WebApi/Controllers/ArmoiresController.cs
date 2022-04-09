using GestPharmaEF.DAL.Repositories;
using GestPharmaEF.Models.Concretes;
using GestPharmaEF.WebApi.JWT_Authentication.JWTWebAuthentication.Repository;
using GestPharmaEF.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestPharmaEF.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ArmoiresController : ControllerBase
    {
        private readonly IJWTManagerRepository _jWTManager;
        private string _jWTEmail;

        public ArmoiresController(IJWTManagerRepository jWTManager)
        {
            this._jWTManager = jWTManager;
        }

        // GET: api/<ArmoiresController>
        [HttpGet]
        [Authorize(Roles = "Admin, Praticien, Patient")]
        public IEnumerable<Armoires>? Get()
        {
            if (HttpContext.User.Identity is ClaimsIdentity identity) { _jWTEmail = identity.FindFirst(ClaimTypes.Name).Value; };
            ArmoireRepository armoireRepository = new();
            return new ObservableCollection<Armoires>(armoireRepository.GetAll()).ToList().Where(x=>x.ArmoPatient == this._jWTEmail);
        }

        // GET api/<ArmoiresController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Praticien")]
        public Armoires? Get(long id)
        {
            if (HttpContext.User.Identity is ClaimsIdentity identity) { _jWTEmail = identity.FindFirst(ClaimTypes.Name).Value; };
            ArmoireRepository armoireRepository = new();
            Armoires ar = armoireRepository.GetOne(id);
            if (ar.ArmoPatient != _jWTEmail) return null;
            return armoireRepository.GetOne(id);
        }

        // POST api/<ArmoiresController>
        [HttpPost]
        [Authorize(Roles = "Admin, Praticien")]
        public void Post([FromBody] J_Armoires newArmoire)
        {
            //if (HttpContext.User.Identity is ClaimsIdentity identity) { _jWTEmail = identity.FindFirst(ClaimTypes.Name).Value; };
            //Armoires armoire = new(
            //            newArmoire.ArmoID,
            //            newArmoire.ArmoName,
            //            newArmoire.ArmoPatient
            //            );
            //armoire.ArmoID = 0;
            //armoire.ArmoPatient = _jWTEmail;
            //ArmoireRepository armoireRepository = new();
            //armoireRepository.Add(armoire);
        }

        // PUT api/<ArmoiresController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Praticien")]
        public void Put(long id, [FromBody] J_Armoires majArmoire)
        {
            //if (HttpContext.User.Identity is ClaimsIdentity identity) { _jWTEmail = identity.FindFirst(ClaimTypes.Name).Value; };
            //Armoires armoire = new(
            //            majArmoire.ArmoID,
            //            majArmoire.ArmoName,
            //            majArmoire.ArmoPatient
            //            );
            //armoire.ArmoID = id;
            //armoire.ArmoPatient = _jWTEmail;
            //ArmoireRepository armoireRepository = new();
            //armoireRepository.Update(armoire);
        }

        // DELETE api/<ArmoiresController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, Praticien")]
        public void Delete(long id)
        {
            //if (HttpContext.User.Identity is ClaimsIdentity identity) { _jWTEmail = identity.FindFirst(ClaimTypes.Name).Value; };
            //ArmoireRepository armoireRepository = new();
            //Armoires ar = armoireRepository.GetOne(id);
            //if (ar.ArmoPatient == _jWTEmail) armoireRepository.Delete(id);
        }
    }
}
