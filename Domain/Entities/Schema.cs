using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Schema: IdEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
        public User Author { get; set; }
        private ICollection<SchemaFile> _files;
        public ICollection<SchemaFile> Files
        {
            get { return _files ?? (_files = new List<SchemaFile>()); }
            set { _files = value; }
        }
        private ICollection<SchemaImage> _images;
        public ICollection<SchemaImage> Images
        {
            get { return _images ?? (_images = new List<SchemaImage>()); }
            set { _images = value; }
        }
        private ICollection<SchemaCategory> _schemaCategories;
        public ICollection<SchemaCategory> SchemaCategories
        {
            get { return _schemaCategories ?? (_schemaCategories = new List<SchemaCategory>()); }
            set { _schemaCategories = value; }
        }
        private ICollection<SchemaStitch> _schemaStitches;
        public ICollection<SchemaStitch> SchemaStitches
        {
            get { return _schemaStitches ?? (_schemaStitches = new List<SchemaStitch>()); }
            set { _schemaStitches = value; }
        }
    }
}
