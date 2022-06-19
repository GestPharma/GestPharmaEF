using GestPharmaEF.Models.Concretes;
using System;
using System.Collections.Generic;

namespace EFCore_DBLibrary
{
    /// <summary>
    /// TRIAL
    /// </summary>
    public partial class Ordonnance
    {
        public Ordonnance()
        {
            ArmoiresStocks = new HashSet<ArmoiresStock>();
        }

        /// <summary>
        /// TRIAL
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Codebarre { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public DateTime? Datecree { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public DateTime? Dateexpire { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public long? Medecinid { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public long? Pharmacieid { get; set; }

        public long? Patientid { get; set; }

        public virtual Medecin Medecin { get; set; }
        public virtual Pharmacy Pharmacie { get; set; }
        public virtual ICollection<ArmoiresStock> ArmoiresStocks { get; set; }

        public virtual Personnes Patient { get; set; }
    }
}
