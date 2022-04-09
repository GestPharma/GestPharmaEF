using GestPharmaEF.DAL.Repositories;
using GestPharmaEF.Models.Concretes;
using GestPharmaEF.WebApi.JWT_Authentication.JWTWebAuthentication.Repository;
using GestPharmaEF.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace GestPharmaEF.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IJWTManagerRepository _jWTManager;

        public RolesController(IJWTManagerRepository jWTManager)
        {
            this._jWTManager = jWTManager;
        }
        // GET: api/<RolesController>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IEnumerable<Roles> Get()
        {
            RoleRepository roleRepository = new();
            return new ObservableCollection<Roles>(roleRepository.GetAll()).ToList();
        }

        // GET api/<RolesController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public Roles Get(long id)
        {
            RoleRepository roleRepository = new();
            return roleRepository.GetOne(id);
        }

        // POST api/<RolesController>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Post([FromBody] J_Roles newRole)
        {
            Roles role = new(
                        newRole.Name
                        );
            role.Id = 0;
            RoleRepository roleRepository = new();
            roleRepository.Add(role);
        }

        // PUT api/<RolesController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public void Put(long id, [FromBody] J_Roles majRole)
        {
            Roles role = new(
                        majRole.Name
                        );
            role.Id = id;
            RoleRepository roleRepository = new();
            roleRepository.Update(role);
        }

        // DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void Delete(long id)
        {
            RoleRepository roleRepository = new();
            roleRepository.Delete(id);
        }
    }
}
