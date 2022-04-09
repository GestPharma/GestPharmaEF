using System;
using System.Collections.Generic;

namespace EFCore_DBLibrary
{
    /// <summary>
    /// TRIAL
    /// </summary>
    public partial class Personne
    {
        /// <summary>
        /// TRIAL
        /// </summary>
        public long PId { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string PEmail { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string PPassword { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public bool PIsActive { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string PConnectAs { get; set; }
        public long? PRoleid { get; set; }
        public virtual Role Roles { get; set; }
    }
}
