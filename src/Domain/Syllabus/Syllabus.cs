using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using net03_group02.src.Domain.Asessment;
using net03_group02.src.Domain.Training;
using net03_group02.src.Domain.User;

namespace net03_group02.src.Domain.Syllabus
{
    public class Syllabus
    {
        [Key]
        public Guid SyllabusId { get; set; }
        public string TopicCode { get; set; } = null!;
        public string TopicName { get; set; } = null!;
        public int Version { get; set; }
        public string? Level { get; set; }
        public string TrainingAudience { get; set; } = "0";
        public string? TechnicalRequirement { get; set; }
        public string? CourseObjective { get; set; }
        public string? TimeLocation { get; set; }
        public string? DeliveryPrinciple { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public User.User CreatedByUser { get; set; } = null!;
        public List<TrainingUnit> TrainingUnits { get; set; } = new();
        public List<TrainingProgramSyllabus> TrainingProgramSyllabuses { get; set; } = new();
        public List<LearningObjective> LearningObjectives { get; set; } = new();
        public List<AsessmentScheme> AsessmentSchemes { get; set; } = new();
    }
}