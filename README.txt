Ok, the tests in this all pass with Resharper 5.1, but all but one fails with Resharper 6.

To get these all to pass with resharper 6, go into ..\SimpleSample\SimpleSample.Test\AbstractRepositoryTests.cs and uncomment this code:

        //[TestCleanup]
        //public void TearDown()
        //{
        //    NHibernateSessionManager.Instance.CloseSession();
        //}


The unit tests to run are in ..\SimpleSample\SimpleSample.Test\UnitTest1.cs