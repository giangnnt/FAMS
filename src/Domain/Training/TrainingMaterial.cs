using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace net03_group02.src.Domain.Training
{
    public partial class TrainingMaterial
    {
        [Key]
        public string Fileupload { get; set; }
        public string Unitcode { get; set; }

        public TrainingUnit TrainingUnit { get; set; } = null!;
    }
}
