using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Domain.Contracts.Repositories
{
    public interface IRoleRepository: IWriteableRepository<Role>
    {
    }
}
