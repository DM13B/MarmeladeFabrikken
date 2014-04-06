using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Planning;
using DataAccess.Planning;
 

namespace Controller.Planning
{
    public class EmployeeController
    {  //Db sync frequency....?
        private List<Employee> MyProperty { get; set; }

        public EmployeeController()
        {
        }
        public void saveEmployee(Employee e) {  } 
        public void createEmployee() {}
        public void updateEmployee() {}
        public void GetAllEmployees() { }
        public void DeleteEmployeeById() { }

        public void GetEmployeeByID() { }
        public void GetEmployeeByName() { } 
        public void GetEmployeeByhrs() { }
        
        //employee stat
        public void GetEmployeeMosthrs() { }
        public void AssignTaskFromProductionContract() { }

        //avg hrs, least hrs, most hrs, avg age, least age. 


    }
}
