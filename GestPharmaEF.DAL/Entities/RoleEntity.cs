using GestPharmaEF.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace GestPharmaEF.DAL
{
    public class RoleEntity : IdentityRole<long>
    {
        public long Id { get; set; } = long.MinValue;
        public string Name { get; set; } = string.Empty;
        public ICollection<PersonneEntity>? Personnes { get; set; }
    }
}
