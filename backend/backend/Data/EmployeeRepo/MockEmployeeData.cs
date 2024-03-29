﻿using backend.Models;
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
            return true;
        }

        public bool EditEmployee(Employee employee)
        {
            databaseContext.Employees.Update(employee);
            return true;
        }

        public Employee GetEmployee(long id)
        {
            return databaseContext.Employees.SingleOrDefault(x => x.Id == id);
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await databaseContext.Employees.ToListAsync();
        }
    }
}
