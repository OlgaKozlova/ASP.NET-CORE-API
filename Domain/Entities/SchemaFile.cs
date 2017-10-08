using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class SchemaFile: IdEntity
    {
        public Guid SchemaId { get; set; }
        public string Title { get; set; }        
        public string Extension { get; set; }
        public byte[] Data { get; set; }
    }
}
