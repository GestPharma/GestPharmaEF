using GestPharmaEF.DAL.Entities;

namespace GestPharmaEF.DAL
    {
    /// <summary>
    /// TRIAL
    /// </summary>
    public partial class MedicamentsPrescritEntity
    {
        /// <summary>
        /// TRIAL
        /// </summary>
        public long Ordonnanceid { get; set; } = long.MinValue;
        /// <summary>
        /// TRIAL
        /// </summary>
        public long Medicamentid { get; set; } = long.MinValue;
        /// <summary>
        /// TRIAL
        /// </summary>
        public long Quantite { get; set; } = long.MinValue;
        /// <summary>
        /// TRIAL
        /// </summary>
        public long Prise { get; set; } = long.MinValue;

        public virtual MedicamentEntity? Medicament { get; set; }
        public virtual OrdonnanceEntity? Ordonnance { get; set; }
    }
}
