using System;
using System.Collections.Generic;

#nullable disable

namespace FAMS.Models
{
    public partial class Syllabus
    {
        public Syllabus()
        {
            AsessmentSchemes = new HashSet<AsessmentScheme>();
            TrainingProgramSyllabi = new HashSet<TrainingProgramSyllabus>();
        }

        public string Topiccode { get; set; }
        public string Topicname { get; set; }
        public string Version { get; set; }
        public string Level { get; set; }
        public string Trainingaudience { get; set; }
        public string Technicalrequirement { get; set; }
        public string Courseobjective { get; set; }
        public string Timelocation { get; set; }
        public string Deliveryprinciple { get; set; }
        public Guid? Createdby { get; set; }
        public DateTime? Createdat { get; set; }
        public Guid? Modifiedby { get; set; }
        public DateTime? Modifiedat { get; set; }

        public virtual User CreatedbyNavigation { get; set; }
        public virtual TrainingUnit TrainingUnit { get; set; }
        public virtual ICollection<AsessmentScheme> AsessmentSchemes { get; set; }
        public virtual ICollection<TrainingProgramSyllabus> TrainingProgramSyllabi { get; set; }
    }
}
