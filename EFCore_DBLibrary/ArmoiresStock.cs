using System;
using System.Collections.Generic;

namespace EFCore_DBLibrary
{
    /// <summary>
    /// TRIAL
    /// </summary>
    public partial class ArmoiresStock
    {
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Medicamentid { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public long? Armoireid { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public long? Ordonnanceid { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public long? Quantite { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public long Mediid { get; set; }

        public virtual Armoire Armoire { get; set; }
        public virtual Medicament Medi { get; set; }
        public virtual Ordonnance Ordonnance { get; set; }
    }
}
