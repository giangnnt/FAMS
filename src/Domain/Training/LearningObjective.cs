using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FAMS.src.Domain.Training
{
    public class LearningObjective
    {
        [Key]
        public Guid LearningObjectiveCode { get; set; }
        public string Name { get; set; } = null!;
        public string? Type { get; set; }
        public string? Description { get; set; }

        public List<Syllabus.Syllabus> Syllabuses { get; set; } = new();
        public TrainingContent TrainingContent { get; set; } = null!;
    }
}