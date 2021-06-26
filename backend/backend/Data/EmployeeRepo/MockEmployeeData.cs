using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace backend.Data.EmployeeRepo
{
    public class MockEmployeeData : IEmployeeData
    {
        public readonly DatabaseContext databaseContext;
        public MockEmployeeData(DatabaseContext context)
        {
            databaseContext = context;
        }
        public Employee AddEmployee(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteEmployee(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public Employee EditEmployee(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public Employee GetEmployee(long Id)
        {
            throw new System.NotImplementedException();
        }

        public List<Employee> GetEmployees()
        {
            return databaseContext.Employees.ToList();
        }
    }
}
