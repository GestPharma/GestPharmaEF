using GestPharmaEF.Models.Interfaces;

namespace GestPharmaEF.WebApi.Models
{
    public class J_Pharmacies : IPharmacies
    {
        public long PharmacieId { get; set; } = long.MinValue;
        public string PharmacieUrl { get; set; } = string.Empty;
        public string PharmacieNom { get; set; } = string.Empty;
        public string PharmacieTitulaires { get; set; } = string.Empty;
        public string PharmacieRue { get; set; } = string.Empty;
        public string PharmacieVilles { get; set; } = string.Empty;
        public string PharmacieDepartement { get; set; } = string.Empty;
        public string PharmacieRegion { get; set; } = string.Empty;
    }
}
