using System.ComponentModel.DataAnnotations;

namespace net03_group02.src.Domain.Asessment;

public partial class AsessmentScheme
{
    [Key]
    public int Id { get; set; }
    public int? Quiz { get; set; }
    public int? Assigment { get; set; }
    public int? Final { get; set; }
    public int? Finaltheory { get; set; }
    public int? Finalpratical { get; set; }
    public int? Gpa { get; set; }
    public Guid SyllabusId { get; set; }

    public Syllabus.Syllabus Syllabus { get; set; } = null!;
}
