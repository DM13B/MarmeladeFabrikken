using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess.Planning;
using Model.Planning;

namespace UnitTests
{
    [TestClass]
    public class TestDataAccessEmployee
    {
        public DataAccessEmployee DataAccessEmployee;
        public Employee emp;
        public TestDataAccessEmployee()
        {
            DataAccessEmployee = new DataAccessEmployee();
            emp = new Employee("hello","bob",25.34m,34.314m);

        }
        [TestMethod]
        public void SaveEmployee()
        {
            DataAccessEmployee.SaveEmployee(emp); 
            

        }
    }
}
