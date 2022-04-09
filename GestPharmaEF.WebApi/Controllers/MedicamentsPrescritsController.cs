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
    public class MedicamentsPrescritsController : ControllerBase
    {
        private readonly IJWTManagerRepository _jWTManager;

        public MedicamentsPrescritsController(IJWTManagerRepository jWTManager)
        {
            this._jWTManager = jWTManager;
        }

        // GET: api/<MedicamentsPrescritsController>
        [HttpGet]
        [Authorize(Roles = "Admin, Praticien, Patient")]
        public IEnumerable<MedicamentsPrescrits> Get()
{
            MedicamentsPrescritRepository medicamentsPrescritsRepository = new();
            return new ObservableCollection<MedicamentsPrescrits>(medicamentsPrescritsRepository.GetAll()).ToList();
        }

        // GET api/<MedicamentsPrescritsController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Praticien")]
        public MedicamentsPrescrits Get(long id)
        {
            MedicamentsPrescritRepository medicamentsPrescritsRepository = new();
            return medicamentsPrescritsRepository.GetOne(id);
        }

        // POST api/<MedicamentsPrescritsController>
        [HttpPost]
        [Authorize(Roles = "Admin, Praticien")]
        public void Post([FromBody] J_MedicamentsPrescrits newMedicamentsPrescrits)
        {
            MedicamentsPrescrits medicamentsPrescrits = new(
                        newMedicamentsPrescrits.MPMedicamentId,
                        newMedicamentsPrescrits.MPOrdonnanceId,
                        newMedicamentsPrescrits.MPQuantite,
                        newMedicamentsPrescrits.MPPrise
                        );
            medicamentsPrescrits.MPMedicamentId = 0;
            MedicamentsPrescritRepository medicamentsPrescritsRepository = new();
            medicamentsPrescritsRepository.Add(medicamentsPrescrits);
        }

        // PUT api/<MedicamentsPrescritsController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Praticien")]
        public void Put(long id, [FromBody] J_MedicamentsPrescrits majMedicamentsPrescrits)
        {
            MedicamentsPrescrits medicamentsPrescrits = new(
                        majMedicamentsPrescrits.MPMedicamentId,
                        majMedicamentsPrescrits.MPOrdonnanceId,
                        majMedicamentsPrescrits.MPQuantite,
                        majMedicamentsPrescrits.MPPrise
                        );
            medicamentsPrescrits.MPMedicamentId = id;
            MedicamentsPrescritRepository medicamentsPrescritsRepository = new();
            medicamentsPrescritsRepository.Update(medicamentsPrescrits);
        }

        // DELETE api/<MedicamentsPrescritsController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, Praticien")]
        public void Delete(long id)
        {
            MedicamentsPrescritRepository medicamentsPrescritsRepository = new();
            medicamentsPrescritsRepository.Delete(id);
        }
    }
}
