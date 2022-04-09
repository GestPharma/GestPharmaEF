using GestPharmaEF.Models.Interfaces;

namespace GestPharmaEF.Models.Concretes
    {
    /// <summary>
    /// </summary>
    public class Medicaments : IMedicaments
        {
        public Medicaments(long Medi_Id, string Medi_Nom)
            {
            MedicamentId = Medi_Id;
            MedicamentNom = Medi_Nom;
            }
        public long MedicamentId { get; set; } = long.MinValue;
        public string MedicamentNom { get; set; } = string.Empty;
        }
    }
