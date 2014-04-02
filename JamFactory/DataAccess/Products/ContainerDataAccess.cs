using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Common.Interfaces;
using DataAccess.Products.Entities;
using System.Data;
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
        public void CreateContainer(IContainer container)
        {
            ContainerEntity c = (ContainerEntity)container;

            using (var cmd = new SqlCommand("ContainerCreate", _conn))
            {
                cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = c.Quantity;
                _conn.Open();
                cmd.ExecuteNonQuery();
            }
            _conn.Close();

        }



    }
}
