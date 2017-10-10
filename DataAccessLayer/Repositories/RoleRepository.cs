using Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using System.Linq;
using Common.Expect;

namespace DataAccessLayer.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly StorageContext _context;

        public RoleRepository(StorageContext context)
        {
            Expect.ArgumentNotNull(context, "context");
            _context = context;
        }

        public void Add(Role entity)
        {
            Expect.ArgumentNotNull(entity, "Role");
            _context.Roles.Add(entity);
        }

        public void Delete(Guid id)
        {
            Expect.ArgumentNotNull(id, "id");
            var Role = _context.Roles.Find(id);
            _context.Roles.Remove(Role);
        }

        public ICollection<Role> GetAll()
        {
            return _context.Roles.ToList();
        }

        public Role GetById(Guid id)
        {
            Expect.ArgumentNotNull(id, "id");
            return _context.Roles.Find(id);
        }

        public void Update(Role entity)
        {
            Expect.ArgumentNotNull(entity, "Role");
            _context.Roles.Update(entity);
        }
    }
}
