using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.CustomerRepo
{
    public interface ICustomerData
    {
        public Task<List<Customer>> GetCustomers();
        public Task<Customer> GetCustomer(long id);
        public Task<bool> AddCustomer(Customer customer);
        public bool UpdateCustomer(Customer customer);
        public bool DeleteCustomer(Customer customer);
    }
}
