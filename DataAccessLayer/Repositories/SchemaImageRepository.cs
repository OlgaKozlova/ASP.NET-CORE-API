using Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace DataAccessLayer.Repositories
{
    public class SchemaImageRepository : ISchemaImageRepository
    {
        private readonly StorageContext _context;

        public SchemaImageRepository(StorageContext context)
        {
            _context = context;
        }

        public void Add(SchemaImage entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public ICollection<SchemaImage> GetAll()
        {
            throw new NotImplementedException();
        }

        public SchemaImage GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(SchemaImage entity)
        {
            throw new NotImplementedException();
        }
    }
}
