using System;
using System.Collections.Generic;
using System.Linq;

namespace leantraining.Models
{
    public class Product : Entity
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Round Round { get; set; }
        public int RoundId { get; set; }

        public string Name { get; set; }
        public List<Part> Parts { get; set; }

        public override string ToString()
        {
            return $"Id:[{Id}] - Start:[{Start.ToString("g")}]";
        }
    }
}