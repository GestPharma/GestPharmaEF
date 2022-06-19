using GestPharmaEF.DAL.Repositories;
using GestPharmaEF.Models.Concretes;
using GestPharmaEF.WebApi.Filters;
using GestPharmaEF.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;


namespace GestPharmaEF.WebApi.Controllers
{
    [Authorization]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PharmaciesController : ControllerBase
    {
        private readonly PharmacieRepository _pharmacieRepository;

        public PharmaciesController(PharmacieRepository pharmacieRepository)
        {
            _pharmacieRepository = pharmacieRepository;
        }

        // GET: api/<PharmaciesController>
        [HttpGet]
        [Authorization("Admin", "Praticien")]
        public IEnumerable<Pharmacies> GetAll()
        {
            return new ObservableCollection<Pharmacies>(_pharmacieRepository.GetAll()).ToList();
        }
        // GET: api/<MedecinsController>
        [HttpGet]
        [Authorization("Admin", "Praticien", "Patient")]
        public IEnumerable<Pharmacies> GetPage([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            return new ObservableCollection<Pharmacies>(_pharmacieRepository.GetAll(limit, offset)).ToList();
        }
        // GET api/<PharmaciesController>/5
        [HttpGet("{id}")]
        [Authorization("Admin", "Praticien", "Patient")]
        public Pharmacies GetOne(long id)
        {
            return _pharmacieRepository.GetOne(id);
        }

        // POST api/<PharmaciesController>
        [HttpPost]
        [Authorization("Admin", "Praticien")]
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
                        )
            {
                PharmacieId = 0
            };
            _pharmacieRepository.Add(pharmacie);
        }

        // PUT api/<PharmaciesController>/5
        [HttpPut("{id}")]
        [Authorization("Admin", "Praticien")]
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
                        )
            {
                PharmacieId = id
            };
            _pharmacieRepository.Update(pharmacie);
        }

        // DELETE api/<PharmaciesController>/5
        [HttpDelete("{id}")]
        [Authorization("Admin", "Praticien")]
        public void Delete(long id)
        {
            _pharmacieRepository.Delete(id);
        }
    }
}
