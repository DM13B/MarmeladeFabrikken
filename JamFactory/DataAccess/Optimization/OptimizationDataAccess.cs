using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Optimization
{
    public class OptimizationDataAccess : DataAccessController
    {
        private SqlConnection _conn;
        public void CreateSqlConnection()
        {
            _conn = new SqlConnection(ConnectionString);
        }

        public void GetAllReceivedGoods()
        {


        }
    }
}
