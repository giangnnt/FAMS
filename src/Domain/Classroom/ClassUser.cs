using System;
using System.Collections.Generic;

#nullable disable

namespace FAMS.src.Domain.Classroom;
public partial class ClassUser
{
    public Guid UserId { get; set; }
    public Guid ClassId { get; set; }
    public string Usertype { get; set; }

    public Class Class { get; set; } = null!;
    public User.User User { get; set; } = null!;
}
