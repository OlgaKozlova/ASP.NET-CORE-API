using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Stitch: IdEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        private ICollection<SchemaStitch> _schemaStitches;
        public ICollection<SchemaStitch> SchemaStitches
        {
            get { return _schemaStitches ?? (_schemaStitches = new List<SchemaStitch>()); }
            set { _schemaStitches = value; }
        }
    }
}
