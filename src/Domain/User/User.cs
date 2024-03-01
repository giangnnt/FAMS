using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FAMS.src.Application.Shared.Enum;
using FAMS.src.Domain;
using FAMS.src.Domain.Classroom;
using FAMS.src.Domain.RoleBase;
using FAMS.src.Domain.Syllabus;
using FAMS.src.Domain.Training;

namespace FAMS.src.Domain.User
{
    public class User
    {

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Phone { get; set; }
        public DateTime? Birthday { get; set; }
        public GenderEnum? Gender { get; set; }
        public int RoleId { get; set; }
        public UserStatusEnum Status { get; set; }
        public DateTime Createdat { get; set; }
        public DateTime UpdateAt { get; set; }

        public Role Role {get; set;} = null!;
        public List<ClassUser> ClassUsers {get; set;} = null!;
        public List<Syllabus.Syllabus> Syllabbuses { get; set; } = new();
        public List<TrainingProgram> Trainingprograms { get; set; } = new();
    }
}
