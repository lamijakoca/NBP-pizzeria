using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.EmployeeRepo
{
    public class MockEmployeeData : IEmployeeData
    {
        public readonly DatabaseContext databaseContext;
        public MockEmployeeData(DatabaseContext context)
        {
            databaseContext = context;
        }
        public async Task<bool> AddEmployee(Employee employee)
        {
            await databaseContext.Employees.AddAsync(employee);
            databaseContext.SaveChanges();
            return true;
        }

        public bool DeleteEmployee(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public bool EditEmployee(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> GetEmployee(long Id)
        {
            throw new System.NotImplementedException();
        }

        public List<Employee> GetEmployees()
        {
            return databaseContext.Employees.ToList();
        }
    }
}
