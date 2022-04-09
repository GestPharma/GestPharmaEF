using System.Collections.Generic;

namespace EFCore_DBLibrary
{
    /// <summary>
    /// TRIAL
    /// </summary>
    public partial class Pharmacy
    {
        public Pharmacy()
        {
            Ordonnances = new HashSet<Ordonnance>();
        }

        /// <summary>
        /// TRIAL
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Nom { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Titulaires { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Rue { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Villes { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Departement { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Region { get; set; }

        public virtual ICollection<Ordonnance> Ordonnances { get; set; }
    }
}
