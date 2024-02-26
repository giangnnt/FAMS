using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using net03_group02.src.Domain.Syllabus;

#nullable disable

namespace net03_group02.src.Domain.Training
{
    public partial class TrainingUnit
    {
        [Key]
        public Guid UnitCode { get; set; }
        public string UnitName { get; set; } = null!;
        public int? DayNumber { get; set; }
        public Guid SyllabusId { get; set; }

        public Syllabus.Syllabus Syllabus { get; set; } = null!;
        public List<TrainingContent> TrainingContents { get; set; } = new();
        public List<TrainingMaterial> TrainingMaterials { get; set; } = new();
    }
}
