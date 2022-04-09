using GestPharmaEF.Models.Interfaces;

namespace GestPharmaEF.Models.Concretes
    {
    public class Pharmacies : IPharmacies
        {
        public Pharmacies(string Url, string Nom, string Titulaires, string Rue, string Villes, string Departement, string Region)
            {
                PharmacieUrl = Url;
                PharmacieNom = Nom;
                PharmacieTitulaires = Titulaires;
                PharmacieRue = Rue;
                PharmacieVilles = Villes;
                PharmacieDepartement = Departement;
                PharmacieRegion = Region;
        }

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
