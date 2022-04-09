namespace GestPharmaEF.Models.Interfaces
{
    public interface IMedecins
    {
        public long MedecinId { get; set; }
        public string MedecinName { get; set; }
        public string MedecinInami { get; set; }
        public string MedecinRue { get; set; }
        public string MedecinVille { get; set; }
        public string MedecinTelephone { get; set; }
        public string MedecinGsm { get; set; }
        public string MedecinFax { get; set; }
        public string MedecinEmail { get; set; }
    }
}