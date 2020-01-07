using System;
using System.Collections.Generic;
using System.Linq;

namespace leantraining.Models
{
    public class Station : Entity
    {
        public string Position { get; set; }
        public Round Round { get; set; }
        public List<StationAssemblyStep> AssemblySteps { get; set; }
    }
}