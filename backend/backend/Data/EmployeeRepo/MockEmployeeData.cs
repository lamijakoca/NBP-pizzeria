using backend.Models;
using Microsoft.EntityFrameworkCore;
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
            databaseContext.Employees.Remove(employee);
            databaseContext.SaveChanges();
            return true;
        }

        public bool EditEmployee(Employee employee)
        {
            databaseContext.Employees.Update(employee);
            databaseContext.SaveChanges();
            return true;
        }

        public async Task<Employee> GetEmployee(long Id)
        {
            return await databaseContext.Employees.FindAsync(Id);
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await databaseContext.Employees.ToListAsync();
        }
    }
}
