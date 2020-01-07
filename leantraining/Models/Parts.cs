using System;
using System.Collections.Generic;

namespace leantraining.Models
{
    public partial class Parts
    {
        public long Id { get; set; }
        public long? ProductId { get; set; }
        public long? PartDefinitionId { get; set; }

        public virtual PartDefinitions PartDefinition { get; set; }
        public virtual Products Product { get; set; }
    }
}
