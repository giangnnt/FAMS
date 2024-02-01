using System;
using System.Collections.Generic;

#nullable disable

namespace FAMS.Models
{
    public partial class ClassUser
    {
        public Guid Userid { get; set; }
        public Guid Classid { get; set; }
        public string Usertype { get; set; }

        public virtual Class Class { get; set; }
        public virtual User User { get; set; }
    }
}
