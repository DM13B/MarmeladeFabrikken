using DataAccess.Products.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Optimization
{
    public class OptimizationDataAccess : DataAccessController
    {
        private SqlConnection _conn;

        public OptimizationDataAccess()
        {
            _conn = new SqlConnection(ConnectionString);
        }

        public List<ReceivedGoodsEntity> GetAllPotentialGoods()
        {
                _conn.Open();
                List<ReceivedGoodsEntity> potentialGoods = new List<ReceivedGoodsEntity>();
                using (var sqlC = new SqlCommand("PotentialGoodsGetAll", _conn))
                {
                    SqlDataReader reader = sqlC.ExecuteReader();
                    while (reader.Read())
                    {
                        ReceivedGoodsEntity potentialGood = new ReceivedGoodsEntity
                        {
                            RawGoods = new RawGoodsEntity((string)reader["RawGoods"]),
                            Amount = (double)reader["Amount"],
                            Price = (decimal)reader["Price"],
                            Received = (DateTime)reader["Received"],
                            Supplier = (string)reader["Supplier"],
                            Id = (int)reader["Id"],
                        };

                        potentialGoods.Add(potentialGood);
                    }
                    _conn.Close();
                }
                return potentialGoods;
        }

        public void CreatePotentialGoods(ReceivedGoodsEntity receivedGood)
        {
            _conn.Open();
            using (var cmd = new SqlCommand("PotentialGoodsCreate", _conn))
            {
                cmd.Parameters.Add("@RawGoods", SqlDbType.NVarChar).Value = receivedGood.RawGoods.Name;
                cmd.Parameters.Add("@Amount", SqlDbType.Float).Value = receivedGood.Amount;
                cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = receivedGood.Price;
                cmd.Parameters.Add("@Received", SqlDbType.DateTime).Value = receivedGood.Received;
                cmd.Parameters.Add("@Supplier", SqlDbType.NVarChar).Value = receivedGood.Supplier;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
            }
            _conn.Close();
        }

        public void DeletePotentialGoods(ReceivedGoodsEntity receivedGood)
        {
            _conn.Open();
            using (var cmd = new SqlCommand("PotentialGoodsDelete", _conn))
            {
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = receivedGood.Id;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
            }
            _conn.Close();
        }

        public void DeleteAllPotentialGoods()
        {
            _conn.Open();
            using (var cmd = new SqlCommand("PotentialGoodsDeleteAll", _conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
            }
            _conn.Close();
        }
    }
}
