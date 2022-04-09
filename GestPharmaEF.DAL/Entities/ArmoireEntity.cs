using System;
using System.Collections;
using System.Collections.Generic;

namespace GestPharmaEF.DAL.Entities
    {
    /// <summary>
    /// TRIAL
    /// </summary>
    public partial class ArmoireEntity
        {
        /// <summary>
        /// TRIAL
        /// </summary>
        public long Id { get; set; } = long.MinValue;
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Nom { get; set; } = string.Empty;
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Patient { get; set; } = string.Empty;

        public virtual ICollection<ArmoiresStockEntity>? ArmoiresStocks { get; set; }
        }
}
