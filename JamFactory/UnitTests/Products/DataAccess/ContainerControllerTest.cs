using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Controller.Products;
using Common.Interfaces;
using System.Collections.Generic;
namespace UnitTests.Products.DataAccess
{
    [TestClass]
    public class ContainerControllerTest
    {
        [TestMethod]
        public void TestGetById()
        {
            ContainerController cc = new ContainerController();
            IContainer ic = cc.GetContainerById(4);
        }
        
        [TestMethod]
        public void TestCreateContainer()
        {
            ContainerController cc = new ContainerController();
            IContainer ic = cc.NewContainer();
            ic.Quantity = 1337;
            ic = cc.SaveContainer(ic);
        }

        [TestMethod]
        public void TestGetAllContainers()
        {
            ContainerController cc = new ContainerController();
            List<IContainer> cl = cc.GetAllContainers();
        }
    }
}
