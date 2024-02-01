using System;
using System.Collections.Generic;

#nullable disable

namespace FAMS.Models
{
    public partial class TrainingMaterial
    {
        public string Fileupload { get; set; }
        public string Unitcode { get; set; }

        public virtual TrainingUnit UnitcodeNavigation { get; set; }
    }
}
