using GestPharmaEF.DAL.Entities;

namespace GestPharmaEF.DAL
{
    public class RoleEntity
    {
        public long Id { get; set; } = long.MinValue;
        public string Name { get; set; } = string.Empty;
        public ICollection<PersonneEntity>? Personnes { get; set; }
    }
}
