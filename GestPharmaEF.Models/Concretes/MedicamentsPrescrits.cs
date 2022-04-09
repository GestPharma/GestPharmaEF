using GestPharmaEF.Models.Interfaces;

namespace GestPharmaEF.Models.Concretes
    {
    /// <summary>
    /// </summary>
    public class MedicamentsPrescrits : IMedicamentsPrescrits
        {
        public MedicamentsPrescrits(long MedicamentId, long OrdonnanceId, long Quantite, long Prise)
            {
            MPMedicamentId = MedicamentId;
            MPOrdonnanceId = OrdonnanceId;
            MPQuantite = Quantite;
            MPPrise = Prise;
            }
        public long MPMedicamentId { get; set; } = long.MinValue;
        public long MPOrdonnanceId { get; set; } = long.MinValue;
        public long MPQuantite { get; set; } = long.MinValue;
        public long MPPrise { get; set; } = long.MinValue;
        }
    }
