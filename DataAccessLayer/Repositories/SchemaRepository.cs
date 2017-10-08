using Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace DataAccessLayer.Repositories
{
    public class SchemaRepository : ISchemaRepository
    {
        private readonly StorageContext _context;

        public SchemaRepository(StorageContext context)
        {
            _context = context;
        }

        public void Add(Schema entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Schema> GetAll()
        {
            throw new NotImplementedException();
        }

        public Schema GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Schema entity)
        {
            throw new NotImplementedException();
        }
    }
}
