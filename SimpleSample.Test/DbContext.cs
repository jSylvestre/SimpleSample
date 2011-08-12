﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace SimpleSample.Test
{
    public class DbContext : IDbContext
    {
        private static ISession Session
        {
            get
            {
                return NHibernateSessionManager.Instance.GetSession();
            }
        }

        /// <summary>
        /// This isn't specific to any one DAO and flushes everything that has been 
        /// changed since the last commit.
        /// </summary>
        public void CommitChanges()
        {
            Session.Flush();
        }

        public void BeginTransaction()
        {
            Session.BeginTransaction();
        }

        public void CommitTransaction()
        {
            Session.Transaction.Commit();
        }

        public void RollbackTransaction()
        {
            Session.Transaction.Rollback();
        }

        public bool IsActive
        {
            get { return Session.Transaction.IsActive; }
        }
    }
}
