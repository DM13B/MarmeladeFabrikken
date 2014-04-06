using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using Model.Planning;
using System.Data.Common;

namespace DataAccess.Planning
{
    public class DataAccessEmployee
    {
            private string connectionstring;
            private static SqlConnection conn;
            static SqlCommand CommandEmployee;

          public DataAccessEmployee() 
          { 
              connectionstring = DataAccessController.ConnectionString;
              CommandEmployee = new SqlCommand("CmdEmployeeCreate");
              conn = new SqlConnection(connectionstring);
              CommandEmployee.Connection = conn;
          }

        
          public void SaveEmployee(Employee employee)
          { 
              
              try
              {  
                  
                  
                  using (SqlConnection sqlconn = new SqlConnection(connectionstring))
                  {

                      using( SqlCommand cmd = new SqlCommand("EmployeeCreate",sqlconn))
                      {
                          cmd.CommandType = System.Data.CommandType.StoredProcedure;
                      cmd.CommandType = System.Data.CommandType.StoredProcedure;
                      cmd.Parameters.Add("@theFirstName", System.Data.SqlDbType.VarChar).Value = employee.FirstName;
                      cmd.Parameters.Add("@theLastName", System.Data.SqlDbType.VarChar).Value = employee.LastName;
                      cmd.Parameters.Add("@theHoursPrWeek", System.Data.SqlDbType.Float).Value = employee.HoursPrWeek;
                      cmd.Parameters.Add("@theHourlyRate", System.Data.SqlDbType.Float).Value = employee.HourlyRate;

                      sqlconn.Open();
                      cmd.ExecuteNonQuery();
                      sqlconn.Close();
                      }
                  }
                  
              }
              catch (Exception ex)
              {
                  //Console Test
                  Console.Write("EmployeeSaveDB threw an ex" + ex.ToString());
              }
         
          }
          
          //test load  saved employee by id 
          public void GetEmployee(Employee emp)
          {
              SqlCommand cmd = new SqlCommand("EmployeeCreate");
              cmd.CommandType = System.Data.CommandType.StoredProcedure;

          }
          
          
                     

    }
}
