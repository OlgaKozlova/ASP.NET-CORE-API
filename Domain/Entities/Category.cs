using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Category: IdEntity
    {
        public string Title { get; set; }
        public string Image { get; set; }
        private ICollection<SchemaCategory> _schemaCategories;
        public ICollection<SchemaCategory> SchemaCategories
        {
            get { return _schemaCategories ?? (_schemaCategories = new List<SchemaCategory>()); }
            set { _schemaCategories = value; }
        }
    }
}
