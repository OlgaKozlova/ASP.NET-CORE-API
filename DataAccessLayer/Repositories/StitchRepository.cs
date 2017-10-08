using Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

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
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Stitch> GetAll()
        {
            throw new NotImplementedException();
        }

        public Stitch GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Stitch entity)
        {
            throw new NotImplementedException();
        }
    }
}
