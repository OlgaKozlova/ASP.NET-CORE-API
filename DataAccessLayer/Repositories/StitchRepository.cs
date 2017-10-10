using Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class StitchRepository : IStitchRepository
    {
        private readonly StorageContext _context;

        public StitchRepository(StorageContext context)
        {
            _context = context;
        }

        public void Add(Stitch entity)
        {
            _context.Stitches.Add(entity);
        }

        public void Delete(Guid id)
        {
            var Stitch = _context.Stitches.Find(id);
            if (Stitch != null)
            {
                _context.Stitches.Remove(Stitch);
            }
           
        }

        public ICollection<Stitch> GetAll()
        {
            return _context.Stitches.ToList();
        }

        public Stitch GetById(Guid id)
        {
            return _context.Stitches.Find(id);
        }

        public void Update(Stitch entity)
        {
            _context.Stitches.Update(entity);
        }
    }
}
