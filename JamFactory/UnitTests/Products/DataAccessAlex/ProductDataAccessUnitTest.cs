using System;
using System.Collections.Generic;
using System.Linq;
using Common.Interfaces;
using DataAccess.Products;
using DataAccess.Products.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Products;

namespace UnitTests.Products.DataAccessAlex
{
    [TestClass]
    public class ProductDataAccessUnitTest
    {
        ProductDataAccess pda = new ProductDataAccess();

        [TestMethod]
        public void TestMethod1()
        {
            List<Product> productList = new List<Product>();

            IProduct product = new Product()
            {
                Description = "hejDescription",
                Name = "hejNavn"
            };
            
            pda.CreateProduct(product);

            IProduct temp = pda.GetProductById(2);

            productList.Add(temp as Product);
            Assert.AreEqual(2, productList[0].Id);
        }
    }
}
