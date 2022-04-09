using System;
using System.Collections.Generic;

namespace GestPharmaEF.DAL.Entities
    {
    /// <summary>
    /// TRIAL
    /// </summary>
    public partial class MedicamentEntity
    {
        /// <summary>
        /// TRIAL
        /// </summary>
        public long Id { get; set; } = long.MinValue;
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Nom { get; set; } = string.Empty;

        public virtual ArmoiresStockEntity? ArmoiresStock { get; set; }
    }
}
