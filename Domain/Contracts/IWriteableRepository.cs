using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contracts
{
    public interface IWriteableRepository<T>: IReadonlyRepository<T> where T: IdEntity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }
}
