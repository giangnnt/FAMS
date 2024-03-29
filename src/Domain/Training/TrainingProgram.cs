﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FAMS.src.Application.Shared.Enum;
using FAMS.src.Domain.Classroom;
using FAMS.src.Domain.User;

#nullable disable

namespace FAMS.src.Domain.Training
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
        public List<TrainingProgramSyllabus> TrainingProgramSyllabus { get; set; } = new();
    }
}
