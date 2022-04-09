using System;
using System.Collections.Generic;

namespace EFCore_DBLibrary
{
    /// <summary>
    /// TRIAL
    /// </summary>
    public partial class Medecin
    {
        public Medecin()
        {
            Ordonnances = new HashSet<Ordonnance>();
        }

        /// <summary>
        /// TRIAL
        /// </summary>
        public long IdMedecin { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Nom { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Inami { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Rue { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Gsm { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Ville { get; set; }

        public virtual ICollection<Ordonnance> Ordonnances { get; set; }
    }
}
