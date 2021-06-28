using backend.Data.CustomerRepo;
using backend.Data.EmployeeRepo;
using backend.Data.PizzaRepo;
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
        public IPizzaData IPizza { get; set; }
        public MockUnitOfWork(DatabaseContext context, IEmployeeData employeeData, ICustomerData customerData, IPizzaData pizzaData)
        {
            _context = context;
            IEmployee = employeeData;
            ICustomer = customerData;
            IPizza = pizzaData;
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
