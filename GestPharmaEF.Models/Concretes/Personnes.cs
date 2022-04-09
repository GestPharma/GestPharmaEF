
namespace GestPharmaEF.Models.Concretes
{
    public class Personnes
    {
        public Personnes(string personnesEmail, string personnesPaswword, bool personnesisactive, long personnesCurrentRoles)
        {
            email = personnesEmail;
            paswword = personnesPaswword;
            isactive = personnesisactive;
            currentrole = personnesCurrentRoles;
        }


        public long Id { get; set; } = long.MinValue;
        public string email { get; set; } = String.Empty;
        public string paswword { get; set; } = String.Empty;
        public bool isactive { get; set; } = false;
        public long currentrole { get; set; } = long.MinValue;
        public string connectas { get; set; } = String.Empty;
    }
}
