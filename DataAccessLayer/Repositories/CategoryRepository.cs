using Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using System.Linq;
using Common.Expect;

namespace DataAccessLayer.Repositories
{
    // ToDo: Uniqueness by title
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StorageContext _context;

        public CategoryRepository(StorageContext context)
        {
            Expect.ArgumentNotNull(context, "context");
            _context = context;
        }

        public ICollection<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetById(Guid id)
        {
            Expect.ArgumentNotNull(id, "id");
            return _context.Categories.Find(id);
        }

        public void Add(Category entity)
        {
            Expect.ArgumentNotNull(entity, "category");
            _context.Categories.Add(entity);
        }

        public void Delete(Guid id)
        {
            Expect.ArgumentNotNull(id, "id");
            var entity =_context.Categories.Find(id);
            if (entity != null)
            {
                _context.Categories.Remove(entity);
            }            
        }
                
        public void Update(Category entity)
        {
            Expect.ArgumentNotNull(entity, "category");
            _context.Categories.Update(entity);
        }
    }
}
