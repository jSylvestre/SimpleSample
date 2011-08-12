using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleSample;

namespace SimpleSample.Test
{
    [TestClass]
    public class UnitTest1 : AbstractRepositoryTests<ExampleTable, int, ExampleTableMap>
    {

        protected override void LoadData()
        {
            Repository.OfType<ExampleTable>().DbContext.BeginTransaction();
            LoadRecords(5);
            Repository.OfType<ExampleTable>().DbContext.CommitTransaction();
        }


        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void TestMethod2()
        {
        }

        [TestMethod]
        public void TestMethod3()
        {
        }
        protected override ExampleTable GetValid(int? counter)
        {
            var rtValue =  new ExampleTable();
            if (counter != null)
            {
                rtValue.Col1 = "Col1" + counter.Value;
            }
            else
            {
                rtValue.Col1 = "Col10";
            }
            rtValue.Col2 = "Col2";

            return rtValue;
        }
    }
}
