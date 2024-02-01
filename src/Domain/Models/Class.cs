using System;
using System.Collections.Generic;

#nullable disable

namespace FAMS.Models
{
    public partial class Class
    {
        public Class()
        {
            ClassUsers = new HashSet<ClassUser>();
        }

        public Guid Classid { get; set; }
        public string Trainprogramcode { get; set; }
        public string Classname { get; set; }
        public string Classcode { get; set; }
        public string Duration { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public string Fsu { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public Guid? Createdby { get; set; }
        public DateTime Createdat { get; set; }
        public Guid? Modifiedby { get; set; }
        public DateTime? Modifiedat { get; set; }

        public virtual User CreatedbyNavigation { get; set; }
        public virtual Trainingprogram TrainprogramcodeNavigation { get; set; }
        public virtual ICollection<ClassUser> ClassUsers { get; set; }
    }
}
