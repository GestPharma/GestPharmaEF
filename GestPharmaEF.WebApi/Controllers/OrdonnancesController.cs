using GestPharmaEF.DAL;
using GestPharmaEF.DAL.Entities;
using GestPharmaEF.DAL.Repositories;
using GestPharmaEF.Models.Concretes;
using GestPharmaEF.WebApi.Filters;
using GestPharmaEF.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Security.Claims;

namespace GestPharmaEF.WebApi.Controllers
{
    [Authorization]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrdonnancesController : ControllerBase
    {
        private readonly OrdonnanceRepository _ordonnanceRepository;
        private readonly BDPMContext _context;
        private string? _jWTEmail = string.Empty;

        public OrdonnancesController(OrdonnanceRepository ordonnanceRepository, BDPMContext context)
        {
            _ordonnanceRepository = ordonnanceRepository;
            _context = context;
        }

        // GET: api/<OrdonnancesController>
        [HttpGet]
        [Authorization("Admin", "Praticien", "Patient")]
        public IEnumerable<Ordonnances> GetAll()
        {
            return new ObservableCollection<Ordonnances>(_ordonnanceRepository.GetAll()).ToList();
        }
        // GET: api/<MedecinsController>
        [HttpGet]
        [Authorization("Admin", "Praticien", "Patient")]
        public IEnumerable<Ordonnances> GetPage([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            PersonneEntity p = new();
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                _jWTEmail = identity?.FindFirst(ClaimTypes.Name)?.Value;
                p = (PersonneEntity)_context.Users.Include(x => x.Roles).ToList().Where(x => x.Email == _jWTEmail);
            };
            return new ObservableCollection<Ordonnances>(_ordonnanceRepository.GetAll(limit, offset)).ToList().Where(x => x.OrdonnancePatient == p.Id);
        }

        // GET api/<OrdonnancesController>/5
        [HttpGet("{id}")]
        [Authorization("Admin", "Praticien", "Patient")]
        public IEnumerable<Ordonnances> GetOne(long id)
        {
            PersonneEntity p = new();
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                _jWTEmail = identity?.FindFirst(ClaimTypes.Name)?.Value;
                p = (PersonneEntity)_context.Users.Include(x => x.Roles).ToList().Where(x => x.Email == _jWTEmail);
            };
            IEnumerable<Ordonnances> aa = _ordonnanceRepository.GetOne2(id);
            foreach (var item in aa) { };
            return aa.AsEnumerable().Where(x => x.OrdonnancePatient == p.Id);
        }

        // POST api/<OrdonnancesController>
        [HttpPost]
        [Authorization("Admin", "Praticien")]
        public void Post([FromBody] J_Ordonnances newOrdonnance)
        {
            PersonneEntity p = new();
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                _jWTEmail = identity?.FindFirst(ClaimTypes.Name)?.Value;
                p = (PersonneEntity)_context.Users.Include(x => x.Roles).ToList().Where(x => x.Email == _jWTEmail);
            };
            Ordonnances ordonnance = new(
                        newOrdonnance.OrdonnanceId,
                        newOrdonnance.OrdonnanceCode_barre,
                        newOrdonnance.OrdonnanceDate_creer,
                        newOrdonnance.OrdonnanceDate_expire,
                        newOrdonnance.OrdonnanceMedecinid,
                        newOrdonnance.OrdonnancePharmacieid,
                        newOrdonnance.OrdonnancePatient
                        )
            {
                OrdonnanceId = 0,
                OrdonnancePatient = p.Id
            };
            _ordonnanceRepository.Add(ordonnance);
        }

        // PUT api/<OrdonnancesController>/5
        [HttpPut("{id}")]
        [Authorization("Admin", "Praticien")]
        public void Put(long id, [FromBody] J_Ordonnances majOrdonnance)
        {
            PersonneEntity p = new();
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                _jWTEmail = identity?.FindFirst(ClaimTypes.Name)?.Value;
                p = (PersonneEntity)_context.Users.Include(x => x.Roles).ToList().Where(x => x.Email == _jWTEmail);
            };
            Ordonnances ordonnance = new(
                        majOrdonnance.OrdonnanceId,
                        majOrdonnance.OrdonnanceCode_barre,
                        majOrdonnance.OrdonnanceDate_creer,
                        majOrdonnance.OrdonnanceDate_expire,
                        majOrdonnance.OrdonnanceMedecinid,
                        majOrdonnance.OrdonnancePharmacieid,
                           majOrdonnance.OrdonnancePatient

                        )
            {
                OrdonnanceId = id,
                OrdonnancePatient = p.Id
            };
            _ordonnanceRepository.Add(ordonnance);
        }

        // DELETE api/<OrdonnancesController>/5
        [HttpDelete("{id}")]
        [Authorization("Admin", "Praticien")]
        public void Delete(long id)
        {
            PersonneEntity p = new();
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                _jWTEmail = identity?.FindFirst(ClaimTypes.Name)?.Value;
                p = (PersonneEntity)_context.Users.Include(x => x.Roles).ToList().Where(x => x.Email == _jWTEmail);
            };
            Ordonnances ar = _ordonnanceRepository.GetOne(id);
            if (ar.OrdonnancePatient == p.Id) _ordonnanceRepository.Delete(id);
            _ordonnanceRepository.Delete(id);
        }
    }
}
