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
    public class PharmaciesController : ControllerBase
    {
        private readonly IJWTManagerRepository _jWTManager;

        public PharmaciesController(IJWTManagerRepository jWTManager)
        {
            this._jWTManager = jWTManager;
        }

        // GET: api/<PharmaciesController>
        [HttpGet]
        [Authorize(Roles = "Admin, Praticien, Patient")]
        public IEnumerable<Pharmacies> Get()
        {
            PharmacieRepository pharmacieRepository = new();
            return new ObservableCollection<Pharmacies>(pharmacieRepository.GetAll()).ToList();
        }

        // GET api/<PharmaciesController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Praticien")]
        public Pharmacies Get(long id)
        {
            PharmacieRepository pharmacieRepository = new();
            return pharmacieRepository.GetOne(id);
        }

        // POST api/<PharmaciesController>
        [HttpPost]
        [Authorize(Roles = "Admin, Praticien")]
        public void Post([FromBody] J_Pharmacies newPharmacie)
        {
            Pharmacies pharmacie = new(
                        newPharmacie.PharmacieUrl,
                        newPharmacie.PharmacieNom,
                        newPharmacie.PharmacieTitulaires,
                        newPharmacie.PharmacieRue,
                        newPharmacie.PharmacieVilles,
                        newPharmacie.PharmacieDepartement,
                        newPharmacie.PharmacieRegion
                        );
            pharmacie.PharmacieId = 0;
            PharmacieRepository pharmacieRepository = new();
            pharmacieRepository.Add(pharmacie);
        }

        // PUT api/<PharmaciesController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Praticien")]
        public void Put(long id, [FromBody] J_Pharmacies majPharmacie)
        {
            Pharmacies pharmacie = new(
                        majPharmacie.PharmacieUrl,
                        majPharmacie.PharmacieNom,
                        majPharmacie.PharmacieTitulaires,
                        majPharmacie.PharmacieRue,
                        majPharmacie.PharmacieVilles,
                        majPharmacie.PharmacieDepartement,
                        majPharmacie.PharmacieRegion
                        );
            pharmacie.PharmacieId = id;
            PharmacieRepository pharmacieRepository = new();
            pharmacieRepository.Update(pharmacie);
        }

        // DELETE api/<PharmaciesController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, Praticien")]
        public void Delete(long id)
        {
            PharmacieRepository pharmacieRepository = new();
            pharmacieRepository.Delete(id);
        }
    }
}
