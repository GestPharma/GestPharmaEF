using GestPharmaEF.Models.Interfaces;

namespace GestPharmaEF.WebApi.Models
{
    public class J_Medecins : IMedecins
    {
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
