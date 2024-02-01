using System;
using System.Collections.Generic;

#nullable disable

namespace FAMS.Models
{
    public partial class Role
    {
        public Role()
        {
            Permissionroles = new HashSet<Permissionrole>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Permissionrole> Permissionroles { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
