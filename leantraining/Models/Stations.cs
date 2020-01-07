using System;
using System.Collections.Generic;

namespace leantraining.Models
{
    public partial class Stations
    {
        public Stations()
        {
            StationsAssemblyStepss = new HashSet<StationsAssemblyStepss>();
        }

        public long Id { get; set; }
        public long? RoundId { get; set; }
        public string Position { get; set; }

        public virtual Rounds Round { get; set; }
        public virtual ICollection<StationsAssemblyStepss> StationsAssemblyStepss { get; set; }
    }
}
