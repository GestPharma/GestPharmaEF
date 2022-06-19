namespace GestPharmaEF.Models.Concretes
{
    public class Roles
    {
        public Roles(string rolesName)
        {
            Name = rolesName;
            //personnes = rolesPersonnes;
        }
        public long Id { get; set; } = long.MinValue;
        public string Name { get; set; } = string.Empty;

        public ICollection<Personnes>? Personnes { get; set; }
    }
}
