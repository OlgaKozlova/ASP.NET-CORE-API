using System;
using System.Collections.Generic;
using System.Text;
using Domain.Contracts.Repositories;
using Domain.Entities;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StorageContext _context;

        public UserRepository(StorageContext context)
        {
            _context = context;
        }

        public void Add(User entity)
        {
            _context.Users.Add(entity);
        }

        public void Delete(Guid id)
        {
            var User = _context.Users.Find(id);
            if (User != null)
            {
                _context.Users.Remove(User);
            }           
        }

        public ICollection<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(Guid id)
        {
            return _context.Users.Find(id);
        }

        public void Update(User entity)
        {
            _context.Users.Update(entity);
        }
    }
}
