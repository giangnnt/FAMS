using System;
using System.Collections.Generic;

#nullable disable

namespace FAMS.Models
{
    public partial class AsessmentScheme
    {
        public int Id { get; set; }
        public int? Quiz { get; set; }
        public int? Assigment { get; set; }
        public int? Final { get; set; }
        public int? Finaltheory { get; set; }
        public int? Finalpratical { get; set; }
        public int? Gpa { get; set; }
        public string Topiccode { get; set; }

        public virtual Syllabus TopiccodeNavigation { get; set; }
    }
}
