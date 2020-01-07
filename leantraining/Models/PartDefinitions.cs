using System;
using System.Collections.Generic;

namespace leantraining.Models
{
    public partial class PartDefinitions
    {
        public PartDefinitions()
        {
            Parts = new HashSet<Parts>();
        }

        public long Id { get; set; }
        public long Cost { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Parts> Parts { get; set; }
    }
}
