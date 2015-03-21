using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace fifi.data
{
    public class BaseContext<TContext> : DbContext where TContext : DbContext
    {
        static BaseContext()
        {
            Database.SetInitializer<TContext>(null);
        }

        protected BaseContext()
            : base("DefaultConnection")
        {
        }
    }
}
