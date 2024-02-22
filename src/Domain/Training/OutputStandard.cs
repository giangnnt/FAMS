using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace net03_group02.src.Domain.Training
{
    public class OutputStandard
    {
        [Key]
        public Guid OutputStandardId { get; set; }
        public string Name { get; set; } = null!;
        public string? Type { get; set; }
        public string? Description { get; set; }

        public List<TrainingContent> TrainingContents = new();
    }
}