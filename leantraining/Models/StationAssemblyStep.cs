using System;
using System.Linq;

namespace leantraining.Models
{
    public class StationAssemblyStep
    {
         public int Id { get; set; }
        public Station Station { get; set; }
        public AssemblyStep AssemblyStep { get; set; } 
    }
}