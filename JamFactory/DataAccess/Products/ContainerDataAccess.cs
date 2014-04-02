using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Common.Interfaces;
using DataAccess.Products.Entities;
using System.Data;
using AutoMapper;
namespace DataAccess.Products
{
    public class ContainerDataAccess : DataAccessController
    {
        private SqlConnection _conn;
        public ContainerDataAccess()
        {
            _conn = new SqlConnection(ConnectionString);
        }


        /// <summary>
        /// Create Container
        /// </summary>
        /// <param name="container">Insert the container to be created in the database</param>
        public ContainerEntity CreateContainer(ContainerEntity container)
        {
            _conn.Open();

            using (var cmd = new SqlCommand("ContainerCreate", _conn))
            {
                var s = new SqlParameter("@Quantity", SqlDbType.Int);
                s.Value = container.Quantity;

                cmd.Parameters.Add(s);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    container.Id = (int)reader["ID"];
                }
            }
            _conn.Close();
            return container;
        }



        /// <summary>
        /// Get Container by ID
        /// </summary>
        /// <param name="id">This is the Container ID that will be searched on.</param>
        public ContainerEntity GetContainerById(int id)
        {
            ContainerEntity p = null;
            _conn.Open();
            using (var sqlC = new SqlCommand("ContainerGetByID", _conn))
            {
                sqlC.CommandType = CommandType.StoredProcedure;
                sqlC.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                SqlDataReader reader = sqlC.ExecuteReader();
                
                while (reader.Read())
                {
                    p = new ContainerEntity
                    {
                        Id = (int)reader["ContainerID"],
                        Quantity = (int)reader["Quantity"]
                    };
                }
            }
            _conn.Close();

  
            return p;
        }


        public List<ContainerEntity> GetAllContainers()
        {
            List<ContainerEntity> cList = new List<ContainerEntity>();
            _conn.Open();
            using (var sqlC = new SqlCommand("ContainerGetAll", _conn))
            {
                sqlC.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlC.ExecuteReader();

                while (reader.Read())
                {
                    cList.Add( new ContainerEntity
                    {
                        Id = (int)reader["ContainerID"],
                        Quantity = (int)reader["Quantity"]
                    });
                }
            }
            _conn.Close();


            return cList;
        }



       

    }
}
