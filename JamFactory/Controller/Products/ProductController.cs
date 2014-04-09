using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common.Interfaces;
using DataAccess.Products;
using DataAccess.Products.Entities;
using Model.Products;

namespace Controller.Products
{
    public class ProductController
    {
        private ProductDataAccess pda;
        private static List<Product> productList;

        public ProductController()
        {
            pda = new ProductDataAccess();
        }

        static ProductController()
        {
            productList = new List<Product>();    
        }

        /// <summary>
        /// Used to instantiate IProduct in GUI.
        /// </summary>
        /// <returns>Return a new Product</returns>
        public Product NewProduct()
        {
            return new Product();
        }
        
        /// <summary>
        /// This method is used to create a new Product, and insert it into the database.
        /// </summary>
        /// <param name="product">Insert the IProduct to create</param>
        public void CreateProduct(IProduct product)
        {
            ProductEntity p = Mapper.DynamicMap<ProductEntity>(product);
            pda.CreateProduct(p);
        }
        
        /// <summary>
        /// Retrieves product from database, based on the specified ID
        /// </summary>
        /// <param name="id">This is the ID that you want to search for</param>
        /// <returns>Return found DB entry as a Product type</returns>
        public Product GetProductById(int id)
        {
            ProductEntity pEntity = pda.GetProductById(id);
            Product p = Mapper.DynamicMap<Product>(pEntity);
            return p;
        }
        /// <summary>
        /// Retrieve all products
        /// </summary>
        /// <returns>All products in the database</returns>
        
        public List<IProduct> GetAllProducts()
        {
            List<ProductEntity> pEntitieslList = pda.GetAllProducts();
            productList = pEntitieslList.Select(Mapper.DynamicMap<Product>).ToList();
            List<IProduct> returnList = productList.Select(t => t as IProduct).ToList();

            return returnList;
        } 
        //u
        public void UpdateProduct(IProduct product)
        {
            ProductEntity pEntity = Mapper.DynamicMap<ProductEntity>(product);
            pda.UpdateProduct(pEntity);
        }
        //d
        public void DeleteProduct(IProduct product)
        {
            ProductEntity pEntity = Mapper.DynamicMap<ProductEntity>(product);
            pda.DeleteProduct(pEntity);
        }
    }
}
