using System;
using System.Collections.Generic;
using System.Linq;

namespace leantraining.Models
{
    public class PartDefinition
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public string Name { get; set; }
        public List<Part> Parts { get; set; }
    }
}