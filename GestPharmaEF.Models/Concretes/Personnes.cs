
namespace GestPharmaEF.Models.Concretes
{
    public class Personnes
    {
        public Personnes(string personnesEmail, string personnesPaswword, bool personnesisactive, long personnesCurrentRoles, string personnesConnectAs)
        {
            Email = personnesEmail;
            Paswword = personnesPaswword;
            Isactive = personnesisactive;
            Currentrole = personnesCurrentRoles;
            Connectas = personnesConnectAs;
        }

        public long Id { get; set; } = long.MinValue;
        public string Email { get; set; } = string.Empty;
        public string Paswword { get; set; } = string.Empty;
        public bool Isactive { get; set; } = false;
        public long Currentrole { get; set; } = long.MinValue;
        public string Connectas { get; set; } = string.Empty;
    }
}
