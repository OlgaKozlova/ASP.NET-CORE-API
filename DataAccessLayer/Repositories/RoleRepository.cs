using Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly StorageContext _context;

        public RoleRepository(StorageContext context)
        {
            _context = context;
        }

        public void Add(Role entity)
        {
            _context.Roles.Add(entity);
        }

        public void Delete(Guid id)
        {
            var Role = _context.Roles.Find(id);
            _context.Roles.Remove(Role);
        }

        public ICollection<Role> GetAll()
        {
            return _context.Roles.ToList();
        }

        public Role GetById(Guid id)
        {
            return _context.Roles.Find(id);
        }

        public void Update(Role entity)
        {
            _context.Roles.Update(entity);
        }
    }
}
