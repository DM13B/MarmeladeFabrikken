using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess.Products;
using Common.Interfaces;
using Model.Products;
namespace UnitTests.Products.DataAccess
{
    [TestClass]
    public class ContainerDataAccessTest
    {
        [TestMethod]
        public void TestCreate()
        {
            IContainer p = new Container
            {
                 Quantity = 22
            };
            ContainerDataAccess da = new ContainerDataAccess();
            da.CreateContainer(p);
            if (2 == 3)
            {
                Assert.Fail();
            }
        }
    }
}
