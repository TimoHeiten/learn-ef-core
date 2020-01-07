using System;
using System.Collections.Generic;

namespace leantraining.Models
{
    public partial class Products
    {
        public Products()
        {
            Parts = new HashSet<Parts>();
        }

        public long Id { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public long? RoundId { get; set; }

        public virtual Rounds Round { get; set; }
        public virtual ICollection<Parts> Parts { get; set; }
    }
}
