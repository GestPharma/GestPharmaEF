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
        public string Name { get; set; } = String.Empty;

        public ICollection<Personnes> personnes { get; set; }
    }
}
