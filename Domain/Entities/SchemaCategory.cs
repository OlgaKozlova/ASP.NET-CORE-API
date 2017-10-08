using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class SchemaCategory: Entity
    {
        public Guid SchemaId { get; set; }
        public Guid CategoryId { get; set; }
        public Schema Schema { get; set; }
        public Category Category { get; set; }
    }
}
