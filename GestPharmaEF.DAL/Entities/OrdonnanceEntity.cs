using System;
using System.Collections.Generic;

namespace GestPharmaEF.DAL.Entities
    { 
    /// <summary>
    /// TRIAL
    /// </summary>
public partial class OrdonnanceEntity
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
        public DateTime Datecree { get; set; } = DateTime.MinValue;
        /// <summary>
        /// TRIAL
        /// </summary>
        public DateTime Dateexpire { get; set; } = DateTime.MinValue;
        /// <summary>
        /// TRIAL
        /// </summary>
        public long Medecinid { get; set; } = long.MinValue;
        /// <summary>
        /// TRIAL
        /// </summary>
        public long Pharmacieid { get; set; } = long.MinValue;

        public virtual MedecinEntity? Medecin { get; set; }
        public virtual PharmacyEntity? Pharmacie { get; set; }
        public virtual ICollection<ArmoiresStockEntity>? ArmoiresStocks { get; set; }
    }
}
