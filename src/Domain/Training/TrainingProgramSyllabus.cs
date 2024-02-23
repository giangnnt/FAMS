using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net03_group02.src.Domain.Training
{
    public class TrainingProgramSyllabus
    {
        public Guid SyllabusId { get; set; }
        public Guid TrainingProgramCode { get; set; }
        public string? Sequence { get; set; }

        public Syllabus.Syllabus Syllabus { get; set; } = null!;
        public TrainingProgram TrainingProgram { get; set; } = null!;
    }
}