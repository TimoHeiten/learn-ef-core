using System;
using System.Collections.Generic;
using System.Linq;

namespace leantraining.Models
{
    public class Station
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public Round Round { get; set; }
        public List<StationAssemblyStep> AssemblySteps { get; set; }
    }
}