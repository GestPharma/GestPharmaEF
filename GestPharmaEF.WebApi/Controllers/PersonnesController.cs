using GestPharmaEF.DAL.Repositories;
using GestPharmaEF.Models.Concretes;
using GestPharmaEF.WebApi.JWT_Authentication.JWTWebAuthentication.Repository;
using GestPharmaEF.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;

namespace GestPharmaEF.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PersonnesController : ControllerBase
    {
        private readonly IJWTManagerRepository _jWTManager;
        private string _jWTEmail;

        public PersonnesController(IJWTManagerRepository jWTManager)
        {
            this._jWTManager = jWTManager;
        }

        // GET: api/<PersonnesController>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IEnumerable<Personnes> GetAll()
        {
            PersonneRepository personneRepository = new();
            return new ObservableCollection<Personnes>(personneRepository.GetAll()).ToList();
        }

        // GET: api/<PersonnesController>
        [HttpGet("{connectAs}")]
        [Authorize(Roles = "Admin, Praticien")]
        public IEnumerable<Personnes> GetAllPatients(string connectAs)
        {
            PersonneRepository personneRepository = new();
            return new ObservableCollection<Personnes>(personneRepository.GetAll()).ToList().Where(x => x.connectas == connectAs);
        }

        // GET api/<PersonnesController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public Personnes GetOne(long id)
        {
            PersonneRepository personneRepository = new();
            return personneRepository.GetOne(id);
        }

        [HttpGet("{id} {connectAs}")]
        [Authorize(Roles = "Admin, Praticien")]
        public Personnes GetOnePatient(long id, string connectAs)
        {
            PersonneRepository personneRepository = new();
            Personnes ar = personneRepository.GetOne(id);
            if (ar.connectas != connectAs) return null;
            return personneRepository.GetOne(id);
        }

        // POST api/<PersonnesController>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Post([FromBody] J_Personnes newPersonne)
        {
            Personnes personne= new(
                        newPersonne.email,
                        EncriptaPassWord(newPersonne.paswword),
                        newPersonne.isactive,
                        newPersonne.currentrole
                        );
            personne.Id = 0;
            personne.connectas = newPersonne.connectAs;
            PersonneRepository personneRepository = new();
            personneRepository.Add(personne);
        }
        // PUT api/<PersonnesController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public void Put(long id, [FromBody] J_Personnes majPersonne)
        {
            Personnes personne = new(
                        majPersonne.email,
                        EncriptaPassWord(majPersonne.paswword),
                        majPersonne.isactive,
                        majPersonne.currentrole
                        );
            personne.Id = id;
            personne.connectas = majPersonne.connectAs;
            PersonneRepository personneRepository = new();
            personneRepository.Update(personne);
        }

        // DELETE api/<PersonnesController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void Delete(long id)
        {
            PersonneRepository personneRepository = new();
            personneRepository.Delete(id);
        }

        //POST api/<PersonnesController>
        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public IActionResult Login(string email, string password)
        {
            Personnes personne = new(
                        email,
                        EncriptaPassWord(password),
                        false,
                        2
                        );
            personne.Id = 0;
            PersonneRepository personneRepository = new();
            //StringSha256Hash (string text) => string.IsNullOrEmpty(text) ? string.Empty : BitConverter.ToString(new System.Security.Cryptography.SHA256Managed().ComputeHash(System.Text.Encoding.UTF8.GetBytes(text))).Replace("-", string.Empty);
            if (!personneRepository.GetUser(email, EncriptaPassWord(password))) return BadRequest();
            else 
            {
                J_Users BigUsers = new();
                BigUsers.email = email;
                BigUsers.paswword = EncriptaPassWord(password);
                var token = _jWTManager.Authenticate(BigUsers);
                if (token == null)
                {
                    return Unauthorized();
                }
                return Ok(token);
            }
        }

        //POST api/<PersonnesController>
        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        public IActionResult Register(string email, string password)
        {
            PersonneRepository personneRepository = new();
            if (!personneRepository.GetUser(email, password))
            {
                Personnes personne = new(
                            email,
                            EncriptaPassWord(password),
                            false,
                            2
                            );
                personne.Id = 0;
                personne.connectas = email;
                personneRepository.Add(personne);
                J_Users BigUsers = new();
                BigUsers.email = email;
                BigUsers.paswword = EncriptaPassWord(password);
                var token = _jWTManager.Authenticate(BigUsers);
                if (token == null)
                {
                    return Unauthorized();
                }
                return Ok(token);
            }
            else
            {
                return BadRequest();
            }
        }
        //POST api/<PersonnesController>
        [HttpPost]
        [Authorize(Roles = "Admin, Praticien")]
        [Route("Create")]
        public IActionResult Create(string email, string password)
        {
            PersonneRepository personneRepository = new();
            if (personneRepository.GetUser(email, password))
            {
                Personnes personne = new(
                            email,
                            EncriptaPassWord(password),
                            false,
                            2
                            );
                personne.Id = 0;
                personne.connectas = _jWTEmail;
                personneRepository.Add(personne);
                J_Users BigUsers = new();
                BigUsers.email = email;
                BigUsers.paswword = EncriptaPassWord(password);
                var token = _jWTManager.Authenticate(BigUsers);
                if (token == null)
                {
                    return Unauthorized();
                }
                return Ok(token);
            }
            else
            {
                return BadRequest();
            }
        }

        public static string EncriptaPassWord(string Password)
        {
            try
            {
                SHA256Managed hasher = new SHA256Managed();

                byte[] pwdBytes = new UTF8Encoding().GetBytes(Password);
                byte[] keyBytes = hasher.ComputeHash(pwdBytes);

                hasher.Dispose();
                return Convert.ToBase64String(keyBytes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
