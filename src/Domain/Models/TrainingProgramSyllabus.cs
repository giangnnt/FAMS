using System;
using System.Collections.Generic;

#nullable disable

namespace FAMS.Models
{
    public partial class TrainingProgramSyllabus
    {
        public string Topiccode { get; set; }
        public string Trainingprogramcode { get; set; }
        public string Sequence { get; set; }

        public virtual Syllabus TopiccodeNavigation { get; set; }
        public virtual Trainingprogram TrainingprogramcodeNavigation { get; set; }
    }
}
