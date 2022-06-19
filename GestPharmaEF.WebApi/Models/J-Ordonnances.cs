using GestPharmaEF.Models.Interfaces;

namespace GestPharmaEF.WebApi.Models
{
    public class J_Ordonnances : IOrdonnances
    {
        public long OrdonnanceId { get; set; } = long.MinValue;
        public string OrdonnanceCode_barre { get; set; } = string.Empty;
        public DateTime OrdonnanceDate_creer { get; set; } = DateTime.MinValue;
        public DateTime OrdonnanceDate_expire { get; set; } = DateTime.MinValue;
        public long OrdonnanceMedecinid { get; set; } = long.MinValue;
        public long OrdonnancePharmacieid { get; set; } = long.MinValue;
        public long OrdonnancePatient { get; set; } = long.MinValue;
    }
}
