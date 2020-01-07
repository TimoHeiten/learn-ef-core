using System;
using System.Collections.Generic;

namespace leantraining.Models
{
    public partial class AssemblySteps
    {
        public AssemblySteps()
        {
            StationsAssemblyStepss = new HashSet<StationsAssemblyStepss>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long Cost { get; set; }

        public virtual ICollection<StationsAssemblyStepss> StationsAssemblyStepss { get; set; }
    }
}
