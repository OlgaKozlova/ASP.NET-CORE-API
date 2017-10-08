﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contracts.Repositories
{
    public interface IUserRepository: IWriteableRepository<User>
    {
    }
}
