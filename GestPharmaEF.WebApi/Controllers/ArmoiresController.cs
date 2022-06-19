using GestPharmaEF.DAL.Entities;
using GestPharmaEF.DAL.Repositories;
using GestPharmaEF.Models.Concretes;
using GestPharmaEF.WebApi.Filters;
using GestPharmaEF.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Collections.ObjectModel;
using System.Security.Claims;

namespace GestPharmaEF.WebApi.Controllers
{
    [Authorization]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ArmoiresController : ControllerBase
    {
        private readonly ArmoireRepository _armoireRepository;
        private readonly PersonneRepository _personneRepository;
        private readonly UserManager<PersonneEntity> _userManager;

        public ArmoiresController(PersonneRepository personneRepository, ArmoireRepository armoireRepository , UserManager<PersonneEntity> userManager)
        {
            _personneRepository = personneRepository;
            _armoireRepository = armoireRepository;
            _userManager = userManager;
        }

        // GET: api/<ArmoiresController>
        [HttpGet]
        [Authorization("Admin", "Praticien", "Patient")]
        public async Task<IEnumerable<Armoires>?> GetAll()
        {
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                PersonneEntity user = await _userManager.FindByNameAsync(identity?.FindFirst(ClaimTypes.Name)?.Value);
                ObservableCollection<Armoires> bb = new();
                var cc = _armoireRepository.GetAll().ToList();
                if (identity?.FindFirst(ClaimTypes.Role)?.Value == "Admin")
                {
                    return new ObservableCollection<Armoires>(cc);
                }
                else if (identity?.FindFirst(ClaimTypes.Role)?.Value == "Praticien")
                {
                    foreach (Personnes item in _personneRepository.GetAll()
                                                                  .Where(x => x.Connectas == user.ConnectAs)
                                                                  .Where(y => y.Email != y.Connectas)
                                                                  .Where(z => z.Isactive = true))
                    {
                        foreach (Armoires item2 in cc.Where(x => x.ArmoPatient == item.Id)) { bb.Add(item2); }
                    }
                    return new ObservableCollection<Armoires>(bb);
                }
                else if (identity?.FindFirst(ClaimTypes.Role)?.Value == "Patient")
                {
                    foreach (Personnes item in _personneRepository.GetAll()
                                                                  .Where(x => x.Email == user.Email)
                                                                  .Where(z => z.Isactive = true))
                    {
                        foreach (Armoires item2 in cc.Where(x => x.ArmoPatient == item.Id)) { bb.Add(item2); }
                    }
                    return new ObservableCollection<Armoires>(bb);
                }
            }
            return null;
        }
        [HttpGet]
        [Authorization("Admin")]
        public IEnumerable<Armoires>? GetPage([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                var cc = _armoireRepository.GetAll(limit, offset).ToList();
                if (identity?.FindFirst(ClaimTypes.Role)?.Value == "Admin")
                {
                    return new ObservableCollection<Armoires>(cc);
                }
            }
            return null;
        }

        // GET api/<ArmoiresController>/5
        [HttpGet("{id}")]
        [Authorization("Admin", "Praticien", "Patient")]
        public async Task<IEnumerable<Armoires>?> GetOne(long id)
        {
            return (await GetAll())?.AsEnumerable().Where(x => x.ArmoID == id);
        }

        // POST api/<ArmoiresController>
        [HttpPost]
        [Authorization("Admin", "Praticien")]
        public async Task<bool>Post([FromBody] J_Armoires newArmoire)
        {
            var result = await GetOne(newArmoire.ArmoID);
            if (result is not null && result.Count() < 1)
            {
                Armoires armoire = new(
                            newArmoire.ArmoID,
                            newArmoire.ArmoName,
                            newArmoire.ArmoPatient
                            );
                if (HttpContext.User.Identity is ClaimsIdentity identity)
                {
                    var user = _userManager.FindByNameAsync(identity?.FindFirst(ClaimTypes.Name)?.Value);
                    armoire.ArmoID = 0;
                    armoire.ArmoPatient = user.Result.Id;
                    _armoireRepository.Add(armoire);
                    return true;
                }
            }
            return false;
        }

        // PUT api/<ArmoiresController>/5
        [HttpPut("{id}")]
        [Authorization("Admin", "Praticien")]
        public async Task<bool>Put(long id, [FromQuery] J_Armoires majArmoire)
        {
            var result = await GetOne(majArmoire.ArmoID);
            if (result is not null && result.Count() > 0)
            {
                Armoires armoire = new(
                        majArmoire.ArmoID,
                        majArmoire.ArmoName,
                        majArmoire.ArmoPatient
                        );
                if (HttpContext.User.Identity is ClaimsIdentity identity)
                {
                    var user = _userManager.FindByNameAsync(identity?.FindFirst(ClaimTypes.Name)?.Value);
                    armoire.ArmoID = id;
                    armoire.ArmoPatient = user.Result.Id;
                    _armoireRepository.Update(armoire);
                    return true;
                }
            }
            return false;
        }

        // DELETE api/<ArmoiresController>/5
        [HttpDelete("{id}")]
        [Authorization("Admin")]
        public async Task<bool?> Delete(long id)
        {
            var result = await GetOne(id);
            if (result is not null && result.Count() > 0) { _armoireRepository.Delete(id); return true; }
            return false;
        }
    }
}
