using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using System.Data.Sql;
using System.Data.SqlClient;


namespace DataAccess.Planning
{
    class DataAccessEmployee
    {

        public const string connString = DataAccessController.ConnectionString;
        SqlConnection conn = new SqlConnection(connString);
        
        public void SaveCreatedEmployee(Employee employee)
        {           conn.Open();
              try
              {
                       SqlCommand cmd = new SqlCommand("EmployeeCreate", conn); // insert command
                              cmd.CommandType = System.Data.CommandType.StoredProcedure;
                              cmd.Parameters.Add("@theFirstName", System.Data.SqlDbType.VarChar).Value = employee.FirstName;
                              cmd.Parameters.Add("@theLastName", System.Data.SqlDbType.VarChar).Value = employee.LastName;
                              cmd.Parameters.Add("@theHoursPrWeek", System.Data.SqlDbType.Float).Value = (float)employee.HoursPrWeek;
                              cmd.Parameters.Add("@theHourlyRate", System.Data.SqlDbType.Float).Value = (float)employee.HourlyRate;
                      
                              conn.Open();
                              cmd.ExecuteNonQuery();     //Boom Shakalakalaka
                      
                              //@theFirstName varchar(100),
                              //@theLastName  varchar(100),
                              //@theHoursPrWeek float,
                              //@theHourlyRate float
                              }
                              catch (Exception)
              {
                  
                  throw;
              }
       
        
        }
    }
}
