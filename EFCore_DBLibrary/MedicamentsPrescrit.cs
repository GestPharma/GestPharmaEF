using System;
using System.Collections.Generic;

namespace EFCore_DBLibrary
{
    /// <summary>
    /// TRIAL
    /// </summary>
    public partial class MedicamentsPrescrit
    {
        /// <summary>
        /// TRIAL
        /// </summary>
        public long? Ordonnanceid { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public long? Medicamentid { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public long? Quantite { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public long? Prise { get; set; }

        public virtual Medicament Medicament { get; set; }
        public virtual Ordonnance Ordonnance { get; set; }
    }
}
