using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestPharmaEF.DAL.Entities
    {
    /// <summary>
    /// TRIAL
    /// </summary>
    public partial class MedecinEntity
    {
        /// <summary>
        /// TRIAL
        /// </summary>
        public long IdMedecin { get; set; } = long.MinValue;
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Nom { get; set; } = string.Empty;
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Inami { get; set; } = string.Empty;
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Rue { get; set; } = string.Empty;
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Telephone { get; set; } = string.Empty;
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Gsm { get; set; } = string.Empty;
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Fax { get; set; } = string.Empty;
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Email { get; set; } = string.Empty;
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Ville { get; set; } = string.Empty;

        public virtual ICollection<OrdonnanceEntity>? Ordonnances { get; set; }
    }
}
