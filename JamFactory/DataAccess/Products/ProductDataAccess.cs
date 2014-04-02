using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public ProductDataAccess()
        {
            _conn = new SqlConnection(ConnectionString);
        }

        /// <summary>
        /// Create Product
        /// </summary>
        /// <param name="product">Insert the product to be created in the database</param>
        public void CreateProduct(ProductEntity product)
        {

            _conn.Open();
            using (var cmd = new SqlCommand("ProductCreate", _conn))
            {
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = product.Name;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = product.Description;
                cmd.Parameters.Add("@ContainerID", SqlDbType.Int).Value = DBNull.Value;
                cmd.Parameters.Add("@ProductTypeID", SqlDbType.Int).Value = DBNull.Value;
                cmd.Parameters.Add("@QualityID", SqlDbType.Int).Value = DBNull.Value;
                cmd.Parameters.Add("@RecipeID", SqlDbType.Int).Value = DBNull.Value;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
            }
            _conn.Close();
        }
        
        /// <summary>
        /// Get product by ID
        /// </summary>
        /// <param name="id">This is the product ID that will be searched on.</param>
        public ProductEntity GetProductById(int id)
        {
            ProductEntity p = null;
            _conn.Open();
            using (var sqlC = new SqlCommand("ProductGetByID", _conn))
            {
                sqlC.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                sqlC.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlC.ExecuteReader();

                while (reader.Read())
                {
                    p = new ProductEntity();

                    p.Id = int.Parse(reader["ProductID"].ToString());
                    p.Name = reader["Name"].ToString();
                    p.Description = reader["Description"].ToString();
                    p.ContainerId = reader["ContainerID"] != DBNull.Value ? int.Parse(reader["ContainerID"].ToString()) : 0;
                    p.ProductTypeId = reader["ProductTypeID"] != DBNull.Value ? int.Parse(reader["ProductTypeID"].ToString()) : 0;
                    p.QualityId = reader["QualityID"] != DBNull.Value ? int.Parse(reader["QualityID"].ToString()) : 0;
                    p.RecipeId = reader["RecipeID"] != DBNull.Value ? int.Parse(reader["RecipeID"].ToString()) : 0;
                }
            }
            _conn.Close();

            return p;
        }

        /// <summary>
        /// Get all products.. nuff said
        /// </summary>
        public List<ProductEntity> GetAllProducts()
        {
            _conn.Open();
            List<ProductEntity> products = new List<ProductEntity>();
            using(var sqlC = new SqlCommand("ProductGetAll", _conn))
            {
                SqlDataReader reader = sqlC.ExecuteReader();
                while (reader.Read())
                {
                    ProductEntity product = new ProductEntity
                    {
                    Id = int.Parse(reader["ProductID"].ToString()),
                    Name = reader["Name"].ToString(),
                    Description = reader["Description"].ToString(),
                    ContainerId = reader["ContainerID"] != DBNull.Value ? int.Parse(reader["ContainerID"].ToString()) : 0,
                    ProductTypeId = reader["ProductTypeID"] != DBNull.Value ? int.Parse(reader["ProductTypeID"].ToString()) : 0,
                    QualityId = reader["QualityID"] != DBNull.Value ? int.Parse(reader["QualityID"].ToString()) : 0,
                    RecipeId = reader["RecipeID"] != DBNull.Value ? int.Parse(reader["RecipeID"].ToString()) : 0,
                    };

                    products.Add(product);
                }
                _conn.Close();
            }
            return products;
        }

        public void UpdateProduct(ProductEntity product)
        {
            _conn.Open();
            using (SqlCommand sqlC = new SqlCommand("ProductUpdate", _conn))
            {
                sqlC.Parameters.Add("@ID", SqlDbType.Int).Value = product.Id;
                sqlC.Parameters.Add("@Name", SqlDbType.NVarChar).Value = product.Name;
                sqlC.Parameters.Add("@Description", SqlDbType.NVarChar).Value = product.Description;
                sqlC.Parameters.Add("@ContainerID", SqlDbType.Int).Value = product.ContainerId;
                sqlC.Parameters.Add("@ProductTypeID", SqlDbType.Int).Value = product.ProductTypeId;
                sqlC.Parameters.Add("@QualityID", SqlDbType.Int).Value = product.QualityId;
                sqlC.Parameters.Add("@RecipeID", SqlDbType.Int).Value = product.RecipeId;

                sqlC.CommandType = CommandType.StoredProcedure;
                sqlC.ExecuteNonQuery();
            }
            _conn.Close();
        }
        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="product">Insert the product that you want to delete</param>
        /// <returns></returns>
        public void DeleteProduct(ProductEntity product)
        {
            _conn.Open();
            using (SqlCommand sqlC = new SqlCommand("ProductDelete", _conn))
            {
                sqlC.Parameters.Add("@ID", SqlDbType.Int).Value = product.Id;
                sqlC.CommandType = CommandType.StoredProcedure;
                sqlC.ExecuteNonQuery();
            }
            _conn.Close();
        }
    }
}