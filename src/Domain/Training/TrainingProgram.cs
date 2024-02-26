using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using net03_group02.src.Application.Shared.Enum;
using net03_group02.src.Domain.Classroom;
using net03_group02.src.Domain.User;

#nullable disable

namespace net03_group02.src.Domain.Training
{
    public partial class TrainingProgram
    {
        [Key]
        public Guid TrainingProgramCode { get; set; }
        public string Name { get; set; } = null!;
        public Guid UserId { get; set; }
        public TimeSpan? Duration { get; set; }
        public TrainingProgramStatusEnum Status { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public User.User User { get; set; } = null!;
        public List<Class> Classes { get; set; } = new();
        public List<TrainingProgramSyllabus> TrainingProgramSyllabuses { get; set; } = new();
    }
}
