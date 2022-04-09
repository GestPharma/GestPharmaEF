using GestPharmaEF.DAL.Entities;

namespace GestPharmaEF.DAL
    {
    /// <summary>
    /// TRIAL
    /// </summary>
    public partial class PharmacyEntity
    {
        /// <summary>
        /// TRIAL
        /// </summary>
        public long Id { get; set; } = long.MinValue;
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Url { get; set; } = string.Empty;
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Nom { get; set; } = string.Empty;
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Titulaires { get; set; } = string.Empty;
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Rue { get; set; } = string.Empty;
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Villes { get; set; } = string.Empty;
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Departement { get; set; } = string.Empty;
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Region { get; set; } = string.Empty;

        public virtual ICollection<OrdonnanceEntity>? Ordonnances { get; set; }
    }
}
