using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace net03_group02.src.Domain.Training
{
    public partial class TrainingMaterial
    {
        [Key]
        public Guid MaterialId { get; set; }
        public string Fileupload { get; set; }
        public string UnitCode { get; set; }

        public TrainingUnit TrainingUnit { get; set; } = null!;
    }
}
