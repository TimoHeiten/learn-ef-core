using System;
using System.Collections.Generic;

namespace leantraining.Models
{
    public partial class Rounds
    {
        public Rounds()
        {
            Products = new HashSet<Products>();
            Stations = new HashSet<Stations>();
        }

        public long Id { get; set; }
        public string Start { get; set; }
        public string End { get; set; }

        public virtual ICollection<Products> Products { get; set; }
        public virtual ICollection<Stations> Stations { get; set; }
    }
}
