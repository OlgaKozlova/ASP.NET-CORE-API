using Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace DataAccessLayer.Repositories
{
    public class SchemaFileRepository : ISchemaFileRepository
    {
        private readonly StorageContext _context;

        public SchemaFileRepository(StorageContext context)
        {
            _context = context;
        }

        public void Add(SchemaFile entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public ICollection<SchemaFile> GetAll()
        {
            throw new NotImplementedException();
        }

        public SchemaFile GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(SchemaFile entity)
        {
            throw new NotImplementedException();
        }
    }
}
