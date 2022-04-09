using GestPharmaEF.DAL.Repositories;
using GestPharmaEF.Models.Concretes;
using GestPharmaEF.WebApi.JWT_Authentication.JWTWebAuthentication.Repository;
using GestPharmaEF.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestPharmaEF.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ArmoiresContenuController : ControllerBase
    {
        private readonly IJWTManagerRepository _jWTManager;

        public ArmoiresContenuController(IJWTManagerRepository jWTManager)
        {
            this._jWTManager = jWTManager;
        }

        // GET: api/<ArmoiresContenuController>
        [HttpGet]
        [Authorize(Roles = "Admin, Praticien, Patient")]
        public IEnumerable<ArmoiresContenu> Get()
        {
            ArmoiresContenuRepository armoiresContenuRepository = new();
            return new ObservableCollection<ArmoiresContenu>(armoiresContenuRepository.GetAll()).ToList();
        }

        // GET api/<ArmoiresContenuController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Praticien")]
        public ArmoiresContenu Get(long id)
        {
            ArmoiresContenuRepository armoiresContenuRepository = new();
            return armoiresContenuRepository.GetOne(id);
        }

        // POST api/<ArmoiresContenuController>
        [HttpPost]
        [Authorize(Roles = "Admin, Praticien")]
        public void Post([FromBody] J_ArmoiresContenu newArmoiresContenu)
        {
            ArmoiresContenu armoiresContenu = new(
                        newArmoiresContenu.ACmedicamentId,
                        newArmoiresContenu.ACarmoireId,
                        newArmoiresContenu.ACordonnanceId,
                        newArmoiresContenu.ACquantite,
                        newArmoiresContenu.ACmediId
                        );
            newArmoiresContenu.ACarmoireId = 0;
            ArmoiresContenuRepository armoiresContenuRepository = new();
            armoiresContenuRepository.Add(armoiresContenu);
        }

        // PUT api/<ArmoiresContenuController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Praticien")]
        public void Put(long id, [FromBody] J_ArmoiresContenu majArmoiresContenu)
        {
            ArmoiresContenu armoiresContenu = new(
                        majArmoiresContenu.ACmedicamentId,
                        majArmoiresContenu.ACarmoireId,
                        majArmoiresContenu.ACordonnanceId,
                        majArmoiresContenu.ACquantite,
                        majArmoiresContenu.ACmediId
                        );
            majArmoiresContenu.ACarmoireId = id;
            ArmoiresContenuRepository armoiresContenuRepository = new();
            armoiresContenuRepository.Update(armoiresContenu);
        }

        // DELETE api/<ArmoiresContenuController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, Praticien")]
        public void Delete(long id)
        {
            ArmoiresContenuRepository armoiresContenuRepository = new();
            armoiresContenuRepository.Delete(id);
        }
    }
}
