using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoMapper;
using Common.Interfaces;
using Controller.Products;
using DataAccess.Products;
using DataAccess.Products.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Products;

namespace UnitTests.Products.DataAccessAlex
{
    [TestClass]
    public class ProductDataAccessUnitTest
    {
        ProductController pc = new ProductController();

        [TestMethod]
        public void TestMethod1()
        {
            
            IProduct product = pc.NewProduct();
            List<IProduct> iProducts = pc.GetAllProducts();
            
            product.Name = "TestingIsSoFun";
            product.Description = "DescriptionTest";

            pc.CreateProduct(product);

            IProduct newProduct = pc.GetProductById(8);
            

            IProduct getNewProductAgain = pc.GetProductById(8);

            Assert.AreEqual(newProduct.Id, getNewProductAgain.Id);
            newProduct.Name = "This is now a changed name";
            newProduct.Id = 2;
            pc.UpdateProduct(newProduct);
            pc.DeleteProduct(getNewProductAgain);

        }
    }
}
