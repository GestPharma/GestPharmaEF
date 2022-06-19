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
    public class MedicamentsPrescritsController : ControllerBase
    {
        private readonly MedicamentsPrescritRepository _medicamentsPrescritsRepository;

        public MedicamentsPrescritsController(MedicamentsPrescritRepository medicamentsPrescritsRepository)
        {
            _medicamentsPrescritsRepository = medicamentsPrescritsRepository;
        }

        // GET: api/<MedicamentsPrescritsController>
        [HttpGet]
        [Authorization("Admin", "Praticien", "Patient")]
        public IEnumerable<MedicamentsPrescrits> GetAll()
        {

            return new ObservableCollection<MedicamentsPrescrits>(_medicamentsPrescritsRepository.GetAll()).ToList();
        }
        // GET: api/<MedecinsController>
        [HttpGet]
        [Authorization("Admin", "Praticien", "Patient")]
        public IEnumerable<MedicamentsPrescrits> GetPage([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            return new ObservableCollection<MedicamentsPrescrits>(_medicamentsPrescritsRepository.GetAll(limit, offset)).ToList();
        }

        // GET api/<MedicamentsPrescritsController>/5
        [HttpGet("{id}")]
        [Authorization("Admin", "Praticien", "Patient")]
        public IEnumerable<MedicamentsPrescrits> GetOne([FromQuery] long id)
        {
            IEnumerable<MedicamentsPrescrits> aa = _medicamentsPrescritsRepository.GetOne2(id);
            foreach (var item in aa) { _ = item; };
            return aa.AsEnumerable();
        }

        // POST api/<MedicamentsPrescritsController>
        [HttpPost]
        [Authorization("Admin", "Praticien")]
        public void Post([FromQuery] J_MedicamentsPrescrits newMedicamentsPrescrits)
        {
            MedicamentsPrescrits medicamentsPrescrits = new(
                        newMedicamentsPrescrits.MPMedicamentId,
                        newMedicamentsPrescrits.MPOrdonnanceId,
                        newMedicamentsPrescrits.MPQuantite,
                        newMedicamentsPrescrits.MPPrise
                        )
            {
                MPMedicamentId = 0
            };
            _medicamentsPrescritsRepository.Add(medicamentsPrescrits);
        }

        // PUT api/<MedicamentsPrescritsController>/5
        [HttpPut("{id}")]
        [Authorization("Admin", "Praticien")]
        public void Put(long id, [FromQuery] J_MedicamentsPrescrits majMedicamentsPrescrits)
        {
            MedicamentsPrescrits medicamentsPrescrits = new(
                        majMedicamentsPrescrits.MPMedicamentId,
                        majMedicamentsPrescrits.MPOrdonnanceId,
                        majMedicamentsPrescrits.MPQuantite,
                        majMedicamentsPrescrits.MPPrise
                        )
            {
                MPMedicamentId = id
            };
            _medicamentsPrescritsRepository.Update(medicamentsPrescrits);
        }

        // DELETE api/<MedicamentsPrescritsController>/5
        [HttpDelete("{id}")]
        [Authorization("Admin", "Praticien")]
        public void Delete(long id)
        {
            _medicamentsPrescritsRepository.Delete(id);
        }
    }
}
