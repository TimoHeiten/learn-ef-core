using System;
using System.Collections.Generic;

namespace leantraining.Models
{
    public partial class StationsAssemblyStepss
    {
        public long Id { get; set; }
        public long? StationId { get; set; }
        public long? AssemblyStepId { get; set; }

        public virtual AssemblySteps AssemblyStep { get; set; }
        public virtual Stations Station { get; set; }
    }
}
