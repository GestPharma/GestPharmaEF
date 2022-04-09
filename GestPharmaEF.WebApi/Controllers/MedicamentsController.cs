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
    public class MedicamentsController : ControllerBase
    {
        private readonly IJWTManagerRepository _jWTManager;

        public MedicamentsController(IJWTManagerRepository jWTManager)
        {
            this._jWTManager = jWTManager;
        }

        // GET: api/<MedicamentsController>
        [HttpGet]
        [Authorize(Roles = "Admin, Praticien, Patient")]
        public IEnumerable<Medicaments> Get()
        {
            MedicamentRepository medicamentRepository = new();
            return new ObservableCollection<Medicaments>(medicamentRepository.GetAll()).ToList();
        }

        // GET api/<MedicamentsController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Praticien")]
        public Medicaments Get(long id)
        {
            MedicamentRepository medicamentRepository = new();
            return medicamentRepository.GetOne(id);
        }

        // POST api/<MedicamentsController>
        [HttpPost]
        [Authorize(Roles = "Admin, Praticien")]
        public void Post([FromBody] J_Medicaments newMedicament)
        {
            Medicaments medicament = new(
                        newMedicament.MedicamentId,
                        newMedicament.MedicamentNom
                        );
            medicament.MedicamentId = 0;
            MedicamentRepository medicamentRepository = new();
            medicamentRepository.Add(medicament);
        }

        // PUT api/<MedicamentsController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Praticien")]
        public void Put(long id, [FromBody] J_Medicaments majMedicament)
        {
            Medicaments medicament = new(
                            majMedicament.MedicamentId,
                            majMedicament.MedicamentNom
                            );
            medicament.MedicamentId = id;
            MedicamentRepository medicamentRepository = new();
            medicamentRepository.Update(medicament);
        }

        // DELETE api/<MedicamentsController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, Praticien")]
        public void Delete(long id)
        {
            MedicamentRepository medicamentRepository = new();
            medicamentRepository.Delete(id);
        }
    }
}
