using System;
using System.Collections.Generic;

#nullable disable

namespace FAMS.Models
{
    public partial class TrainingContent
    {
        public string Contentname { get; set; }
        public string Outputstandard { get; set; }
        public int? Trainingtime { get; set; }
        public bool? Method { get; set; }
        public string Deliverytype { get; set; }
        public string Unitcode { get; set; }

        public virtual TrainingUnit UnitcodeNavigation { get; set; }
    }
}
