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
    public class MedicamentsController : ControllerBase
    {
        private readonly MedicamentRepository _medicamentRepository;

        public MedicamentsController(MedicamentRepository medicamentRepository)
        {
            _medicamentRepository = medicamentRepository;
        }

        [HttpGet]
        [Authorization("Admin", "Praticien", "Patient")]
        public IEnumerable<Medicaments> GetAll()
        {
            return new ObservableCollection<Medicaments>(_medicamentRepository.GetAll()).ToList();
        }
        // GET: api/<MedicamentsController>
        [HttpGet]
        [Authorization("Admin", "Praticien", "Patient")]
        public IEnumerable<Medicaments> GetPage([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            return new ObservableCollection<Medicaments>(_medicamentRepository.GetAll(limit, offset)).ToList();
        }

        // GET api/<MedicamentsController>/5
        [HttpGet("{id}")]
        [Authorization("Admin", "Praticien", "Patient")]
        public IEnumerable<Medicaments> GetOne(long id)
        {
            IEnumerable<Medicaments> aa = _medicamentRepository.GetOne2(id);
            foreach (var item in aa) { _ = item; };
            return aa.AsEnumerable();

        }

        // POST api/<MedicamentsController>
        [HttpPost]
        [Authorization("Admin", "Praticien")]
        public void Post([FromQuery] J_Medicaments newMedicament)
        {
            Medicaments medicament = new(
                        newMedicament.MedicamentId,
                        newMedicament.MedicamentNom
                        )
            {
                MedicamentId = 0
            };
            _medicamentRepository.Add(medicament);
        }

        // PUT api/<MedicamentsController>/5
        [HttpPut("{id}")]
        [Authorization("Admin", "Praticien")]
        public void Put(long id, [FromQuery] J_Medicaments majMedicament)
        {
            Medicaments medicament = new(
                            majMedicament.MedicamentId,
                            majMedicament.MedicamentNom
                            )
            {
                MedicamentId = id
            };
            _medicamentRepository.Update(medicament);
        }

        // DELETE api/<MedicamentsController>/5
        [HttpDelete("{id}")]
        [Authorization("Admin", "Praticien")]
        public void Delete(long id)
        {
            _medicamentRepository.Delete(id);
        }
    }
}
