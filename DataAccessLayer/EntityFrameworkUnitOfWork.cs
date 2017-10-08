using System;
using System.Collections.Generic;
using System.Text;
using Domain.Contracts;
using Domain.Contracts.Repositories;
using DataAccessLayer.Repositories;

namespace DataAccessLayer
{
    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        private StorageContext _context;
        public EntityFrameworkUnitOfWork(StorageContext context)
        {
            _context = context;
        }

        private IUserRepository _userRepostitory;

        public IUserRepository UserRepository
        {
            get { return _userRepostitory ?? (_userRepostitory = new UserRepository(_context)); }
        }

        private IRoleRepository _roleRepostitory;

        public IRoleRepository RoleRepository
        {
            get { return _roleRepostitory ?? (_roleRepostitory = new RoleRepository(_context)); }
        }

        private ISchemaRepository _schemaRepository;

        public ISchemaRepository SchemaRepository {
            get { return _schemaRepository ?? (_schemaRepository = new SchemaRepository(_context)); }
        }

        private IStitchRepository _stitchRepository;

        public IStitchRepository StitchRepository {
            get { return _stitchRepository ?? (_stitchRepository = new StitchRepository(_context)); }
        }

        private ICategoryRepository _categoryRepository;

        public ICategoryRepository CategoryRepository
        {
            get { return _categoryRepository ?? (_categoryRepository = new CategoryRepository(_context)); }
        }

        private ISchemaFileRepository _schemaFileRepository;

        public ISchemaFileRepository SchemaFileRepository
        {
            get { return _schemaFileRepository ?? (_schemaFileRepository = new SchemaFileRepository(_context)); }
        }

        private ISchemaImageRepository _schemaImageRepository;

        public ISchemaImageRepository SchemaImageRepository
        {
            get { return _schemaImageRepository ?? (_schemaImageRepository = new SchemaImageRepository(_context)); }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
