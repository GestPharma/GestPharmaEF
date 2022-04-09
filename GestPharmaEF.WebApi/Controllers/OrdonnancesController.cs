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
    public class OrdonnancesController : ControllerBase
    {
        private readonly IJWTManagerRepository _jWTManager;

        public OrdonnancesController(IJWTManagerRepository jWTManager)
        {
            this._jWTManager = jWTManager;
        }

        // GET: api/<OrdonnancesController>
        [HttpGet]
        [Authorize(Roles = "Admin, Praticien, Patient")]
        public IEnumerable<Ordonnances> Get()
        {
            OrdonnanceRepository ordonnanceRepository = new();
            return new ObservableCollection<Ordonnances>(ordonnanceRepository.GetAll()).ToList();
        }

        // GET api/<OrdonnancesController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Praticien")]
        public Ordonnances Get(long id)
        {
            OrdonnanceRepository ordonnanceRepository = new();
            return ordonnanceRepository.GetOne(id);
        }

        // POST api/<OrdonnancesController>
        [HttpPost]
        [Authorize(Roles = "Admin, Praticien")]
        public void Post([FromBody] J_Ordonnances newOrdonnance)
        {
            Ordonnances ordonnance = new(
                        newOrdonnance.OrdonnanceId,
                        newOrdonnance.OrdonnanceCode_barre,
                        newOrdonnance.OrdonnanceDate_creer, 
                        newOrdonnance.OrdonnanceDate_expire,
                        newOrdonnance.OrdonnanceMedecinid,
                        newOrdonnance.OrdonnancePharmacieid
                        );
            ordonnance.OrdonnanceId = 0;
            OrdonnanceRepository ordonnanceRepository = new();
            ordonnanceRepository.Add(ordonnance);
        }

        // PUT api/<OrdonnancesController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Praticien")]
        public void Put(long id, [FromBody] J_Ordonnances majOrdonnance)
        {
            Ordonnances ordonnance = new(
                        majOrdonnance.OrdonnanceId,
                        majOrdonnance.OrdonnanceCode_barre,
                        majOrdonnance.OrdonnanceDate_creer,
                        majOrdonnance.OrdonnanceDate_expire,
                        majOrdonnance.OrdonnanceMedecinid,
                        majOrdonnance.OrdonnancePharmacieid
                        );
            ordonnance.OrdonnanceId = id;
            OrdonnanceRepository ordonnanceRepository = new();
            ordonnanceRepository.Add(ordonnance);
        }

        // DELETE api/<OrdonnancesController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, Praticien")]
        public void Delete(long id)
        {
            OrdonnanceRepository ordonnanceRepository = new();
            ordonnanceRepository.Delete(id);
        }
    }
}
