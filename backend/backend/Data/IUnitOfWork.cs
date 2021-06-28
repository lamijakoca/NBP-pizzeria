using backend.Data.CustomerRepo;
using backend.Data.EmployeeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data
{
    public interface IUnitOfWork
    {
        public IEmployeeData IEmployee { get; set; }
        public ICustomerData ICustomer { get; set; }
        Task<bool> Complete();
    }
}
