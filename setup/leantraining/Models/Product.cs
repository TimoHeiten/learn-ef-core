using System;
using System.Collections.Generic;
using System.Linq;

namespace leantraining.Models
{
    public class Product
    {
         public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Round Round { get; set; }
        public List<Part> Parts { get; set; }
    }
}