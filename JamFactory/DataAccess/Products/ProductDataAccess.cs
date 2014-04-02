using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using Common.Interfaces;
using DataAccess.Products.Entities;

namespace DataAccess.Products
{
    public class ProductDataAccess : DataAccessController
    {
        private SqlConnection _conn;
        public void CreateSqlConnection()
        {
            _conn = new SqlConnection(ConnectionString);
        }

        /// <summary>
        /// Create Product
        /// </summary>
        /// <param name="product">Insert the product to be created in the database</param>
        public void CreateProduct(IProduct product)
        {
            ProductEntity p = (ProductEntity)product;

            using (var cmd = new SqlCommand("ProductCreate", _conn))
            {
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = p.Id;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = p.Name;
                cmd.Parameters.Add("@ContainerID", SqlDbType.Int).Value = DBNull.Value;
                cmd.Parameters.Add("@ProductTypeID", SqlDbType.Int).Value = DBNull.Value;
                cmd.Parameters.Add("@QualityID", SqlDbType.Int).Value = DBNull.Value;
                cmd.Parameters.Add("@RecipeID", SqlDbType.Int).Value = DBNull.Value;
                _conn.Open();
                cmd.ExecuteNonQuery();
            }

            _conn.Close();

        }
        /// <summary>
        /// Get product by ID
        /// </summary>
        /// <param name="id">This is the product ID that will be searched on.</param>
        public void GetProductById(int id)
        {
            ProductEntity p = new ProductEntity();

            using (var sqlC = new SqlCommand("ProductGetByID", _conn))
            {
                sqlC.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                _conn.Open();
                sqlC.ExecuteNonQuery();
            }
            _conn.Close();
            //Still needs a return
        }

        /// <summary>
        /// Get all products.. nuff said
        /// </summary>
        public void GetAllProducts()
        {
            using(var sqlC = new SqlCommand("ProductGetAll", _conn))
            {
               
            }
        }

    }
}