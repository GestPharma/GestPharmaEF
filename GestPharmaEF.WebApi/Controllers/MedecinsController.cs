using GestPharmaEF.DAL.Repositories;
using GestPharmaEF.Models.Concretes;
using GestPharmaEF.WebApi.JWT_Authentication.JWTWebAuthentication.Repository;
using GestPharmaEF.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.ObjectModel;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestPharmaEF.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MedecinsController : ControllerBase
    {
        private readonly IJWTManagerRepository _jWTManager;
        public MedecinsController(IJWTManagerRepository jWTManager)
        {
            this._jWTManager = jWTManager;
        }

        // GET: api/<MedecinsController>
        [HttpGet]
        [Authorize(Roles = "Admin, Praticien, Patient")]
        public IEnumerable<Medecins> Get()
        {
            MedecinRepository medecinRepository = new();
            return new ObservableCollection<Medecins>(medecinRepository.GetAll()).ToList();
        }

        // GET api/<MedecinsController>/5
        [HttpGet("{id}", Name = "getone")]
        [Authorize(Roles = "Admin, Praticien")]
        public IEnumerable<Medecins> Get(long id)
        {
            MedecinRepository medecinRepository = new();
            IEnumerable<Medecins> aa = medecinRepository.GetOne2(id);
            foreach (var item in aa)  { };
            return aa.AsEnumerable();
        }
        // POST api/<MedecinsController>/create
        [HttpPost]
        [Route("create")]
        [Authorize(Roles = "Admin, Praticien")]
        public void Post(J_Medecins newMedecin)
        //public void Post(J_Medecins newMedecin)
        {
            Medecins medecin = new(
                                    newMedecin.MedecinName,
                                    newMedecin.MedecinInami,
                                    newMedecin.MedecinRue,
                                    newMedecin.MedecinVille,
                                    newMedecin.MedecinTelephone,
                                    newMedecin.MedecinGsm,
                                    newMedecin.MedecinFax,
                                    newMedecin.MedecinEmail
                                    );
            medecin.MedecinId = 0;
            MedecinRepository medecinRepository = new();
            medecinRepository.Add(medecin);
        }

        // PUT api/<MedecinsController>/update/5
        [HttpPut]
        [Route("update/{id}")]
        [Authorize(Roles = "Admin, Praticien")]
        public void Put(long id, [FromBody] J_Medecins majMedecin)
        {
            Medecins medecin = new(
                        majMedecin.MedecinName,
                        majMedecin.MedecinInami,
                        majMedecin.MedecinRue,
                        majMedecin.MedecinVille,
                        majMedecin.MedecinTelephone,
                        majMedecin.MedecinGsm,
                        majMedecin.MedecinFax,
                        majMedecin.MedecinEmail
                        );
            medecin.MedecinId = id;
            MedecinRepository medecinRepository = new();
            medecinRepository.Update(medecin);
        }

        // DELETE api/<MedecinsController>/delete/5
        [HttpDelete]
        [Route("delete/{id}")]
        [Authorize(Roles = "Admin, Praticien")]
        public void Delete(long id)
        {
            MedecinRepository medecinRepository = new();
            medecinRepository.Delete(id);
        }
    }
}
