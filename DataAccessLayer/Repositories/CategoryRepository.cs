using Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    // ToDo: Uniqueness by title
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StorageContext _context;

        public CategoryRepository(StorageContext context)
        {
            _context = context;
        }

        public void Add(Category entity)
        {
            _context.Categories.Add(entity);
        }

        public void Delete(Guid id)
        {
            var entity =_context.Categories.Find(id);
            _context.Categories.Remove(entity);
        }

        public ICollection<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetById(Guid id)
        {
            return _context.Categories.Find(id);
        }

        public void Update(Category entity)
        {
            _context.Categories.Update(entity);
        }
    }
}
