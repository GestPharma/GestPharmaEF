using GestPharmaEF.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GestPharmaEF.DAL.Entities
{
    public partial class PersonneEntity : IdentityUser<long>
    {
        public override string? Email { get; set; }

        public string? Password { get; set; }

        public bool? IsActive { get; set; }
        public long? CurrentRoleId { get; set; }
        public string? ConnectAs { get; set; }

       public virtual ICollection<OrdonnanceEntity>? Ordonnances { get; set; }

        public virtual ICollection<ArmoireEntity>? Armoires { get; set; }

        public virtual ICollection<RoleEntity>? Roles { get; set; }
    }
}
