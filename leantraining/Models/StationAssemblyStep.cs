using System;
using System.Linq;

namespace leantraining.Models
{
    public class StationAssemblyStep : Entity
    {
        public Station Station { get; set; }
        public AssemblyStep AssemblyStep { get; set; } 
    }
}