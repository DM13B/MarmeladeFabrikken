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
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = p.Name;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = p.Description;
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
        public IProduct GetProductById(int id)
        {
            ProductEntity p = null;

            using (var sqlC = new SqlCommand("ProductGetByID", _conn))
            {
                sqlC.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                SqlDataReader reader = sqlC.ExecuteReader();

                while (reader.Read())
                {
                    p = new ProductEntity
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                        ContainerId = reader.GetInt32(3),
                        ProductTypeId = reader.GetInt32(4),
                        QualityId = reader.GetInt32(5),
                        RecipeId = reader.GetInt32(6)
                    };
                }
            }
            _conn.Close();

            return p as IProduct;
        }

        /// <summary>
        /// Get all products.. nuff said
        /// </summary>
        public List<ProductEntity> GetAllProducts()
        {
            List<ProductEntity> products = new List<ProductEntity>();
            using(var sqlC = new SqlCommand("ProductGetAll", _conn))
            {
                SqlDataReader reader = sqlC.ExecuteReader();

                while (reader.Read())
                {
                    ProductEntity product = new ProductEntity
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                        ContainerId = reader.GetInt32(3),
                        ProductTypeId = reader.GetInt32(4),
                        QualityId = reader.GetInt32(5),
                        RecipeId = reader.GetInt32(6)
                    };

                    products.Add(product);
                }
                _conn.Close();
            }
            return products;
        }

        public void UpdateProduct(IProduct product)
        {
            using (SqlCommand sqlC = new SqlCommand("ProductUpdate", _conn))
            {
                sqlC.Parameters.Add("@ID", SqlDbType.Int).Value = product.Id;
                sqlC.Parameters.Add("@Name", SqlDbType.NVarChar).Value = product.Name;
                sqlC.Parameters.Add("@Description", SqlDbType.Int).Value = product.Description;
                sqlC.Parameters.Add("@ContainerID", SqlDbType.Int).Value = product.ContainerId;
                sqlC.Parameters.Add("@ProductTypeID", SqlDbType.Int).Value = product.ProductTypeId;
                sqlC.Parameters.Add("@QualityID", SqlDbType.Int).Value = product.QualityId;
                sqlC.Parameters.Add("@RecipeID", SqlDbType.Int).Value = product.RecipeId;
                sqlC.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="product">Insert the product that you want to delete</param>
        /// <returns></returns>
        public void DeleteProduct(IProduct product)
        {
            using (SqlCommand sqlC = new SqlCommand("ProductDelete", _conn))
            {
                sqlC.Parameters.Add("@ID", SqlDbType.Int).Value = product.Id;
                sqlC.ExecuteNonQuery();
            }
        }
    }
}