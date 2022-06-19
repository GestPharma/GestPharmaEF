using GestPharmaEF.DAL.Repositories;
using GestPharmaEF.Models.Concretes;
using GestPharmaEF.WebApi.JWT_Authentication.JWTWebAuthentication.Repository;
using GestPharmaEF.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Identity;
using GestPharmaEF.DAL.Entities;
using GestPharmaEF.DAL;
using GestPharmaEF.WebApi.Filters;
using Microsoft.EntityFrameworkCore;

namespace GestPharmaEF.WebApi.Controllers
{
    [Authorization]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PersonnesController : ControllerBase
    {
        private readonly IJWTManagerRepository _jWTManager;
        private readonly PersonneRepository _personneRepository;
        private readonly SignInManager<PersonneEntity> _signInManager;
        private readonly UserManager<PersonneEntity> _userManager;
        private readonly RoleManager<RoleEntity> _roleManager;
        private readonly ArmoireRepository _armoireRepository;
        private readonly BDPMContext _context;

        public PersonnesController( IJWTManagerRepository jWTManager, 
                                    PersonneRepository personneRepository, 
                                    SignInManager<PersonneEntity> signInManager, 
                                    UserManager<PersonneEntity> userManager, 
                                    RoleManager<RoleEntity> roleManager,
                                    BDPMContext context,
                                    ArmoireRepository armoireRepository
            )
        {
            _jWTManager = jWTManager;
            _personneRepository = personneRepository;
            _armoireRepository = armoireRepository;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        // GET: api/<PersonnesController>
        [HttpGet]
        [Authorization("Admin", "Praticien")]
        public IEnumerable<PersonneEntity> GetAll()
        {
            return _context.Users.Include(x => x.Roles).ToList() ;
        }

        [HttpGet]
        [Authorization("Admin", "Praticien")]
        public IEnumerable<PersonneEntity> GetAllAs([FromQuery] string connectAs)
        {
            return new ObservableCollection<PersonneEntity>(_context.Users.Include(x => x.Roles).ToList())
                .Where(x => x.ConnectAs == connectAs && x.IsActive == true);
        }

        // GET api/<PersonnesController>/5
        [HttpGet]
        [Authorization("Admin", "Praticien")]
        public IEnumerable<Personnes>? GetOne([FromQuery] long id)
        {
            IEnumerable<Personnes> aa = _personneRepository.GetOne2(id);
            if (aa != null) {
                foreach (var item in aa) { _ = item; };
                return aa.AsEnumerable();
            }
            return null;
        }

        [HttpGet]
        [Authorization("Admin", "Praticien")]
        public Personnes? GetOneAs([FromQuery] long id, [FromQuery] string connectAs)
        {
            Personnes ar = _personneRepository.GetOne(id);
            if (ar != null) {
                if (ar.Connectas != connectAs) return null;
                if (ar.Isactive != true) return null;
                return _personneRepository.GetOne(id);
            }
            return null;
        }

        // POST api/<PersonnesController>
        [HttpPost]
        [Authorization("Admin", "Praticien")]
        public async Task<IActionResult> Post([FromQuery] J_Personnes newPersonne)
        {
            PersonneEntity user = new();
            var result = await _signInManager.CheckPasswordSignInAsync(user, newPersonne.Paswword, false);
            if (result.Succeeded)
            {
                user.ConnectAs = newPersonne.ConnectAs;
                user.IsActive = newPersonne.Isactive;
                user.CurrentRoleId = newPersonne.Currentrole;
                user.Email = newPersonne.Email;
                user.UserName = newPersonne.Email;
                user.EmailConfirmed = true;
                user.SecurityStamp = (DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
            }
            try
            {
                _context.Personnes.Add(user);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                _context.Personnes.Remove(user);
                return BadRequest();
            }
        }
        // PUT api/<PersonnesController>/5
        [HttpPut("{id}")]
        [Authorization("Admin", "Praticien")]
        public async Task<IActionResult> Put(long id, [FromBody] J_Personnes majPersonne)
        {
            PersonneEntity user = await _userManager.FindByIdAsync(id.ToString());
            var result = await _signInManager.CheckPasswordSignInAsync(user, majPersonne.Paswword, false);
            if (result.Succeeded)
            {
                user.ConnectAs = majPersonne.ConnectAs;
                user.IsActive = majPersonne.Isactive;
                user.CurrentRoleId = majPersonne.Currentrole;
                user.Email = majPersonne.Email;
                user.UserName = majPersonne.Email;
                user.EmailConfirmed = true;
                user.SecurityStamp = (DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
            }
            try
            {
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                _context.Personnes.Remove(user);
                return BadRequest();
            }
        }

        // DELETE api/<PersonnesController>/5
        [HttpDelete("{id}")]
        [Authorization("Admin", "Praticien")]
        public async Task<IActionResult> Delete(long id)
        {
            PersonneEntity user = await _userManager.FindByIdAsync(id.ToString());
            user.IsActive = false;
            try
            {
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                _context.Personnes.Remove(user);
                return BadRequest();
            }
        }

        // Login ouvert à tout le monde
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            PersonneEntity p = await _userManager.FindByNameAsync(email);
            if (p != null)
            {
                if (p.IsActive == true)
                {
                    var ar = _armoireRepository.GetAll();
                    if (!ar.Any(x => x.ArmoPatient == p.Id && x.ArmoName == email.ToUpper() + " : Pilulier"))
                    {
                        Armoires pilulier = new(0, email.ToUpper() + " : Pilulier", p.Id);
                        _armoireRepository.Add(pilulier);
                    }
                    if (!ar.Any(x => x.ArmoPatient == p.Id && x.ArmoName == email.ToUpper() + " : Armoire"))
                    {
                        Armoires armoire = new(0, email.ToUpper() + " : Armoire", p.Id);
                        _armoireRepository.Add(armoire);
                    }
                    var result = await _signInManager.CheckPasswordSignInAsync(p, password, false);
                    if (result.Succeeded)
                    {
                        J_Users BigUsers = new()
                        {
                            Email = email
                        };
                        RoleEntity q = await _roleManager.FindByIdAsync(p.CurrentRoleId.ToString());
                        BigUsers.Role = q.Name;

                        var token = _jWTManager.Authenticate(BigUsers);
                        if (token == null)
                        {
                            return Unauthorized();
                        }
                        return Ok(token);
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
                else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return Unauthorized();
            }
        }

        // tous les patients ont connectAs = email par defaut => n'ont pas praticien : Ouvert a tout le monde
        [HttpPost]
        public async Task<IActionResult> RegisterPatient(string email, string password)
        {
            PersonneEntity p = await _userManager.FindByNameAsync(email);
            if (p == null)
            {
                PersonneEntity user = new()
                {
                    Email = email,
                    CurrentRoleId = 2,
                    UserName = email,
                    ConnectAs = email,
                    IsActive = false,
                    EmailConfirmed = true,
                    SecurityStamp = (DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds.ToString()
                };
                var result = await _userManager.CreateAsync(user, password);
                try
                {
                    _context.SaveChanges();
                    PersonneEntity r = await _userManager.FindByNameAsync(email);
                    Armoires pilulier = new(0, email.ToUpper() + " : Pilulier", r.Id);
                    _armoireRepository.Add(pilulier);
                    Armoires armoire = new(0, email.ToUpper()+" : Armoire", r.Id);
                    _armoireRepository.Add(armoire);
                    return Ok();
                }
                catch (Exception)
                {
                    _context.Personnes.Remove(user);
                    return BadRequest(result.Errors);
                }
            }
            else {
                return BadRequest();
            }
        }

        [HttpPost]
        [Authorization("Admin")]
        // C'est l'admin qui peut enregistrer un praticien
        public async Task<IActionResult> RegisterPraticien(string emailPraticien, string passwordPraticien)
        {
            PersonneEntity p = await _userManager.FindByNameAsync(emailPraticien);
            if (p == null)
            {
                    PersonneEntity user = new()
                    {
                        Email = emailPraticien,
                        CurrentRoleId = 3,
                        UserName = emailPraticien,
                        ConnectAs = emailPraticien,
                        IsActive = true,
                        EmailConfirmed = true,
                        SecurityStamp = (DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds.ToString()
                    };
                _ = await _userManager.CreateAsync(user, passwordPraticien);
                try
                    {
                        _context.SaveChanges();
                        return Ok();
                    }
                    catch (Exception)
                    {
                        _context.Personnes.Remove(user);
                        return BadRequest();
                    }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Authorization("Admin", "Praticien")]
        // le patient prend dans connectas l'émail du praticien => vérification ligin du praticien
        public async Task<IActionResult> RegisterPatientToPraticien(string praticienEmail, string praticienPassword, string patientEmail)
        {
            PersonneEntity p = await _userManager.FindByNameAsync(patientEmail);
            if (p != null)
            {
                PersonneEntity q = await _userManager.FindByNameAsync(praticienEmail);
                if (q != null)
                {
                    var result = await _signInManager.CheckPasswordSignInAsync(p, praticienPassword, false);
                    if (result.Succeeded)
                    {
                        p.ConnectAs = praticienEmail;
                        p.IsActive = true;
                        try
                        {
                            _context.SaveChanges();
                            return Ok();
                        }
                        catch (Exception)
                        {
                            _context.Personnes.Remove(p);
                            return BadRequest();
                        }
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }        
    }
}
