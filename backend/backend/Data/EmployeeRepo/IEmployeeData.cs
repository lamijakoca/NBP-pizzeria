using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.EmployeeRepo
{
    public interface IEmployeeData
    {
        public Task<List<Employee>> GetEmployees();

        public Employee GetEmployee(long Id);
        public Task<bool> AddEmployee(Employee employee);
        public bool DeleteEmployee(Employee employee);
        public bool EditEmployee(Employee employee);
    }
}
