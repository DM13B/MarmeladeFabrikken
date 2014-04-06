using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Planning;
using DataAccess.Planning;



namespace PlanningDbTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee c = new Employee("Kevin", "Magnussen",25,25);
            DataAccessEmployee datEmp = new DataAccessEmployee();
            datEmp.SaveEmployee(c);



            Console.Read();
             
        }
    }
}
