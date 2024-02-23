
using System.ComponentModel.DataAnnotations;
using net03_group02.src.Application.Shared.Enum;
using net03_group02.src.Domain.Training;
using net03_group02.src.Domain.User;

namespace net03_group02.src.Domain.Classroom;

public partial class Class
{
    [Key]
    public Guid ClassId { get; set; }
    public Guid TrainingProgramCode { get; set; }
    public string ClassName { get; set; } = null!;
    public string? ClassCode { get; set; }
    public TimeSpan? Duration { get; set; }
    public ClassStatusEnum Status { get; set; }
    public string? Location { get; set; }
    public string? FSU { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedAt { get; set; }

    public List<ClassUser> ClassUsers {get; set;} = new();
    public TrainingProgram TrainingProgram {get; set;} = null!;
}
