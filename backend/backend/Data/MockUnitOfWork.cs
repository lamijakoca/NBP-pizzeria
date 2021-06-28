using backend.Data.CustomerRepo;
using backend.Data.EmployeeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data
{
    public class MockUnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        public IEmployeeData IEmployee { get; set; }
        public ICustomerData ICustomer { get; set; }
        public MockUnitOfWork(DatabaseContext context, IEmployeeData employeeData, ICustomerData customerData)
        {
            _context = context;
            IEmployee = employeeData;
            ICustomer = customerData;
        }
        public async Task<bool> Complete()
        {
            var save = await _context.SaveChangesAsync();

            if (save == 1)
                return true;
            else return false;
        }
    }
}
