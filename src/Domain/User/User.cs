using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using net03_group02.src.Application.Shared.Enum;
using net03_group02.src.Domain;
using net03_group02.src.Domain.Classroom;
using net03_group02.src.Domain.RoleBase;
using net03_group02.src.Domain.Syllabus;
using net03_group02.src.Domain.Training;

namespace net03_group02.src.Domain.User
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
        public int Roleid { get; set; }
        public UserStatusEnum Status { get; set; }
        public DateTime Createdat { get; set; }
        public DateTime UpdateAt { get; set; }

        public Role Role {get; set;} = null!;
        public List<ClassUser> ClassUsers {get; set;} = null!;
        public List<Syllabus.Syllabus> Syllabbuses { get; set; } = new();
        public List<TrainingProgram> TrainingPrograms { get; set; } = new();
    }
}
