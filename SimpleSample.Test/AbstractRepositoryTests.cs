using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleSample.Test
{
    // ReSharper disable InconsistentNaming
    [TestClass]
    public abstract class AbstractRepositoryTests<T, IdT, TMap> : FluentRepositoryTestBase<TMap>
    // ReSharper restore InconsistentNaming
    {
        protected int EntriesAdded;
        protected string RestoreValue;
        protected bool BoolRestoreValue;
        protected int? IntRestoreValue;
        protected DateTime DateTimeRestoreValue;
        private readonly IRepository<T> _intRepository;


        #region Init

        protected AbstractRepositoryTests()
        {
            //HibernatingRhinos.NHibernate.Profiler.Appender.NHibernateProfiler.Initialize();
            if (typeof(IdT) == typeof(int))
            {
                _intRepository = new Repository<T>();
            }

        }

        /// <summary>
        /// Gets the valid entity of type T
        /// </summary>
        /// <param name="counter">The counter.</param>
        /// <returns>A valid entity of type T</returns>
        protected abstract T GetValid(int? counter);


        /// <summary>
        /// Loads the records for CRUD Tests.
        /// </summary>
        /// <returns></returns>
        protected virtual void LoadRecords(int entriesToAdd)
        {
            EntriesAdded += entriesToAdd;
            for (int i = 0; i < entriesToAdd; i++)
            {
                var validEntity = GetValid(i + 1);
                if (typeof(IdT) == typeof(int))
                {
                    _intRepository.EnsurePersistent(validEntity);
                }
            }
        }

        /// <summary>
        /// ************************************************************************************
        /// ************************************************************************************
        /// Implement this to get it to run with resharper 6
        /// ************************************************************************************
        /// ************************************************************************************
        /// </summary>
        //[TestCleanup]
        //public void TearDown()
        //{
        //    NHibernateSessionManager.Instance.CloseSession();
        //}

        protected override void InitServiceLocator()
        {
            //base.InitServiceLocator();
            var container = ServiceLocatorInitializer.Init();

            base.RegisterAdditionalServices(container);
        }

        #endregion Init

        #region CRUD Tests

        /// <summary>
        /// Determines whether this instance [can save valid entity].
        /// </summary>
        [TestMethod]
        public void CanSaveValidEntity()
        {
            var validEntity = GetValid(null);
            if (typeof(IdT) == typeof(int))
            {
                _intRepository.EnsurePersistent(validEntity);
            }

           
        }


        /// <summary>
        /// Determines whether this instance [can commit valid entity].
        /// </summary>
        [TestMethod]
        public void CanCommitValidEntity()
        {
            var validEntity = GetValid(null);
            if (typeof(IdT) == typeof(int))
            {
                _intRepository.DbContext.BeginTransaction();
                _intRepository.EnsurePersistent(validEntity);

                _intRepository.DbContext.CommitTransaction();
            }


        }



        /// <summary>
        /// Determines whether this instance [can get null value using get by nullable with invalid id where id is int].
        /// </summary>
        [TestMethod]
        public virtual void CanGetNullValueUsingGetByNullableWithInvalidId()
        {
            if (typeof(IdT) == typeof(int))
            {
                var foundEntity = _intRepository.GetNullableById(EntriesAdded + 1);
                Assert.IsNull(foundEntity);
            }

        }


        #endregion CRUD Tests

        #region Utilities



        /// <summary>
        /// Abstract Repository Tests Action
        /// </summary>
        public enum ARTAction
        {
            Compare = 1,
            Update,
            Restore,
            CompareNotUpdated
        }
        #endregion Utilities


    }
}
