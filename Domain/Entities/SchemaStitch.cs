using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class SchemaStitch: Entity
    {
        public Guid SchemaId { get; set; }
        public Guid StitchId { get; set; }
        public Schema Schema { get; set; }
        public Stitch Stitch { get; set; }
    }
}
