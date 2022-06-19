using System.Collections.Generic;

namespace EFCore_DBLibrary
    {
    /// <summary>
    /// TRIAL
    /// </summary>
    public partial class Armoire
    {
        public Armoire()
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
        public string Nom { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public long Patientid { get; set; }

        public virtual ICollection<ArmoiresStock> ArmoiresStocks { get; set; }
    }
}
