using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSample.Test
{
    public interface IDbContext
    {
        void CommitChanges();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        bool IsActive { get; }
    }
}
