using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.EmployeeRepo
{
    public interface IEmployeeData
    {
        List<Employee> GetEmployees();

        Employee GetEmployee(long Id);
        Employee AddEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        Employee EditEmployee(Employee employee);
    }
}
