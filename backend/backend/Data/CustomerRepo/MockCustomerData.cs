using backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.CustomerRepo
{
    public class MockCustomerData : ICustomerData
    {
        private readonly DatabaseContext databaseContext;
        public MockCustomerData(DatabaseContext context)
        {
            databaseContext = context;
        }

        public async Task<bool> AddCustomer(Customer customer)
        {
            await databaseContext.Customers.AddAsync(customer);
            return true;
        }

        public bool DeleteCustomer(Customer customer)
        {
            databaseContext.Customers.Remove(customer);
            return true;
        }

        public async Task<Customer> GetCustomer(long id)
        {
            return await databaseContext.Customers.FindAsync(id);
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await databaseContext.Customers.ToListAsync();
        }

        public bool UpdateCustomer(Customer customer)
        {
            databaseContext.Customers.Update(customer);
            return true;
        }
    }
}