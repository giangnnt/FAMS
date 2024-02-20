using System;
using System.Collections.Generic;

#nullable disable

namespace FAMS.Models
{
    public partial class User
    {
        public User()
        {
            ClassUsers = new HashSet<ClassUser>();
            Classes = new HashSet<Class>();
            Syllabi = new HashSet<Syllabus>();
            Trainingprograms = new HashSet<Trainingprogram>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Phone { get; set; }
        public DateTime? Dob { get; set; }
        public string Gender { get; set; }
        public int? Roleid { get; set; }
        public string Status { get; set; }
        public DateTime Createdat { get; set; }
        public DateTime Updateat { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<ClassUser> ClassUsers { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Syllabus> Syllabi { get; set; }
        public virtual ICollection<Trainingprogram> Trainingprograms { get; set; }
    }
}
