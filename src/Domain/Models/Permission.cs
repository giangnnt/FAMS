using System;
using System.Collections.Generic;

#nullable disable

namespace FAMS.Models
{
    public partial class Permission
    {
        public Permission()
        {
            Permissionroles = new HashSet<Permissionrole>();
        }

        public string Permissionid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Permissionrole> Permissionroles { get; set; }
    }
}
