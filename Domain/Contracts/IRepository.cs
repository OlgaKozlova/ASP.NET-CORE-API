﻿using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Domain.Contracts
{
    public interface IRepository<T> where T: IdEntity
    {
    }
}
