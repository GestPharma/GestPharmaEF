using GestPharmaEF.Models.Interfaces;

namespace GestPharmaEF.Models.Concretes
{
    /// <summary>
    /// </summary>
    public class Medecins : IMedecins
        {
        public Medecins(string nom, string inami, string rue, string ville, string telephone, string gsm, string fax, string email)
            {
            MedecinName = nom;
            MedecinInami = inami;
            MedecinRue = rue;
            MedecinVille = ville;
            MedecinTelephone = telephone;
            MedecinGsm = gsm;
            MedecinFax = fax;
            MedecinEmail = email;
            }
        #region Fields

        public long MedecinId { get; set; } = long.MinValue;
        public string MedecinName { get; set; } = string.Empty;
        public string MedecinInami { get; set; } = string.Empty;
        public string MedecinRue { get; set; } = string.Empty;
        public string MedecinVille { get; set; } = string.Empty;
        public string MedecinTelephone { get; set; } = string.Empty;
        public string MedecinGsm { get; set; } = string.Empty;
        public string MedecinFax { get; set; } = string.Empty;
        public string MedecinEmail { get; set; } = string.Empty;

        #endregion
        }
    }
