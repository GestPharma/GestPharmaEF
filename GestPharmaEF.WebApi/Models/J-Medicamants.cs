using GestPharmaEF.Models.Interfaces;

namespace GestPharmaEF.WebApi.Models
{
    public class J_Medicaments : IMedicaments
    {
        public long MedicamentId { get; set; } = long.MinValue;
        public string MedicamentNom { get; set; } = string.Empty;
    }
}
