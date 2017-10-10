using Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Common.Expect;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class SchemaFileRepository : ISchemaFileRepository
    {
        private readonly StorageContext _context;

        public SchemaFileRepository(StorageContext context)
        {
            Expect.ArgumentNotNull(context, "context");
            _context = context;
        }

        public void Add(SchemaFile entity)
        {
            Expect.ArgumentNotNull(entity, "SchemaFile");
            _context.SchemaFiles.Add(entity);
        }

        public void Delete(Guid id)
        {
            Expect.ArgumentNotNull(id, "id");
            var SchemaFile = _context.SchemaFiles.Find(id);
            if (SchemaFile != null)
            {
                _context.SchemaFiles.Remove(SchemaFile);
            }
        }

        public ICollection<SchemaFile> GetAll()
        {
            return _context.SchemaFiles.ToList();
        }

        public SchemaFile GetById(Guid id)
        {
            Expect.ArgumentNotNull(id, "id");
            return _context.SchemaFiles.Find(id);
        }

        public void Update(SchemaFile entity)
        {
            Expect.ArgumentNotNull(entity, "SchemaFile");
            _context.SchemaFiles.Update(entity);
        }
    }
}
