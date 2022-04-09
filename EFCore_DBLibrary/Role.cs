using System.Collections.Generic;

namespace EFCore_DBLibrary
{
    public partial class Role
    {
        public Role()
        {
            CurrentRole = new HashSet<Personne>();
        }
        /// <summary>
        /// TRIAL
        /// </summary>
        public long RoleId { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string RoleName { get; set; }

        public virtual ICollection<Personne> CurrentRole { get; set; }
    }
}
