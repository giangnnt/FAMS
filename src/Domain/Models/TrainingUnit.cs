using System;
using System.Collections.Generic;

#nullable disable

namespace FAMS.Models
{
    public partial class TrainingUnit
    {
        public string Unitcode { get; set; }
        public string Unitname { get; set; }
        public int? Daynumber { get; set; }
        public string Topiccode { get; set; }

        public virtual Syllabus TopiccodeNavigation { get; set; }
    }
}
