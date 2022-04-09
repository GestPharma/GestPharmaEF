using System;
using System.Collections.Generic;

namespace GestPharmaEF.DAL.Entities
    {
    /// <summary>
    /// TRIAL
    /// </summary>
    public partial class ArmoiresStockEntity
    {
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Medicamentid { get; set; } = string.Empty;
        /// <summary>
        /// TRIAL
        /// </summary>
        public long? Armoireid { get; set; } = long.MinValue;
        /// <summary>
        /// TRIAL
        /// </summary>
        public long? Ordonnanceid { get; set; } = long.MinValue;
        /// <summary>
        /// TRIAL
        /// </summary>
        public long? Quantite { get; set; } = long.MinValue;
        /// <summary>
        /// TRIAL
        /// </summary>
        public long Mediid { get; set; } = long.MinValue;

        public virtual ArmoireEntity? Armoire { get; set; }
        public virtual MedicamentEntity? Medi { get; set; }
        public virtual OrdonnanceEntity? Ordonnance { get; set; }
    }
}
