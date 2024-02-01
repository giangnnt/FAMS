using System;
using System.Collections.Generic;

#nullable disable

namespace FAMS.Models
{
    public partial class Trainingprogram
    {
        public Trainingprogram()
        {
            Classes = new HashSet<Class>();
            TrainingProgramSyllabi = new HashSet<TrainingProgramSyllabus>();
        }

        public string Trainingprogramcode { get; set; }
        public string Name { get; set; }
        public Guid? Userid { get; set; }
        public string Duration { get; set; }
        public string Topiccode { get; set; }
        public string Status { get; set; }
        public Guid Createdby { get; set; }
        public DateTime Createdat { get; set; }
        public Guid? Modifiedby { get; set; }
        public DateTime? Modifiedat { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<TrainingProgramSyllabus> TrainingProgramSyllabi { get; set; }
    }
}
