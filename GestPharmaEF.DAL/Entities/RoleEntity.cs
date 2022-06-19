using GestPharmaEF.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GestPharmaEF.DAL
{
    public class RoleEntity : IdentityRole<long>
    {
        public override long Id { get; set; } = long.MinValue;
        public override string Name { get; set; } = string.Empty;
        public ICollection<PersonneEntity>? Personnes { get; set; }
    }
}
