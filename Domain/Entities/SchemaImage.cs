using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class SchemaImage: IdEntity
    {
        public Guid SchemaId { get; set; }
        public string Title { get; set; }
        public string Extension { get; set; }
        public byte[] Image { get; set; }
    }
}
