using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FAMS.src.Application.Shared.Enum;

namespace FAMS.src.Domain.Training
{
    public partial class TrainingContent
    {
        [Key]
        public Guid TrainingContentId { get; set; }
        public string ContentName { get; set; } = null!;
        public TimeSpan? Trainingtime { get; set; }
        public TrainingContentMethodEnum Method { get; set; }
        public TrainingContentDeliveryTypeEnum? DeliveryType { get; set; }
        public Guid UnitCode { get; set; }

        public TrainingUnit TrainingUnit { get; set; } = null!;
        public List<LearningObjective> LearningObjectives { get; set; } = new();
        public OutputStandard OutputStandard { get; set; } = null!;
    }
}
