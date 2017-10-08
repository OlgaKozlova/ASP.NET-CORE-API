using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchemaApi
{
    public static class DbInitializer
    {
        public static void Initialize(StorageContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
