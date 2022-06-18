using GestPharmaEF.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace GestPharmaEF.DAL.Entities
{
    public partial class PersonneEntity : IdentityUser<long>
    {
        public long? Id { get; set; }
        public string? Email { get; set; }

        public string? Password { get; set; }

        public bool? IsActive { get; set; }
        public long? CurrentRoleId { get; set; }
        public string? ConnectAs { get; set; }
        public virtual RoleEntity? Roles { get; set; }

    }
}
