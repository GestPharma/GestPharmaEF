using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public long Patientid { get; set; } = long.MinValue;

        public virtual ICollection<ArmoiresStockEntity>? ArmoiresStocks { get; set; }

        public virtual PersonneEntity? Patient { get; set; }

    }
}
