using System;
using System.Linq;

namespace leantraining.Models
{
    public class Round
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
    }
}