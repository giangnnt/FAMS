using System;
using System.Collections.Generic;

#nullable disable

namespace FAMS.Models
{
    public partial class Permissionrole
    {
        public string Permissionid { get; set; }
        public int Roleid { get; set; }

        public virtual Permission Permission { get; set; }
        public virtual Role Role { get; set; }
    }
}
