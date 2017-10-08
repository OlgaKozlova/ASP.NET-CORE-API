using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contracts
{
    public interface IReadonlyRepository<T>: IRepository<T> where T: IdEntity
    {
        T GetById(Guid id);
        ICollection<T> GetAll();
    }
}
