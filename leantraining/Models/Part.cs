using System;
using System.Linq;

namespace leantraining.Models
{
    public class Part
    {
         public int Id { get; set; }
        public Product Product { get; set; }
        public PartDefinition PartDefinition { get; set; } 
    }
}