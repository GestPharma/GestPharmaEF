using System;
using System.Collections.Generic;

namespace EFCore_DBLibrary
{
    /// <summary>
    /// TRIAL
    /// </summary>
    public partial class Medicament
    {
        /// <summary>
        /// TRIAL
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Nom { get; set; }

        public virtual ArmoiresStock ArmoiresStock { get; set; }
    }
}
