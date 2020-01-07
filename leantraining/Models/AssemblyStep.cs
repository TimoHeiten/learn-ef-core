using System;
using System.Collections.Generic;
using System.Linq;

namespace leantraining.Models
{
    public class AssemblyStep
    {
        public int Id { get; set; }
         public string Name { get; set; }
        public int Cost { get; set; }
        public List<StationAssemblyStep> StationAssemblySteps { get; set; }
    }
}