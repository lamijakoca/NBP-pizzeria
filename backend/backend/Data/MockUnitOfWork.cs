using backend.Data.AuthRepo;
using backend.Data.CustomerRepo;
using backend.Data.EmployeeRepo;
using backend.Data.HelpRepo;
using backend.Data.Ingredients;
using backend.Data.PizzaActualRepo;
using backend.Data.PizzaRepo;
using backend.Data.StorageRepo;
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
        public IIngredients IIngredient { get; set; }
        public IAuthData IAuth { get; set; }
        public IStorageData IStorageData { get; set; }
        public IPizzaActualData IPizzaActualData { get; set; }
        public IOrders IOrders { get; set; }
        public MockUnitOfWork(
            DatabaseContext context, 
            IEmployeeData employeeData, 
            ICustomerData customerData, 
            IPizzaData pizzaData,
            IIngredients ingredients,
            IAuthData authData,
            IStorageData storage, 
            IPizzaActualData pizzaActual,
            IOrders order)
        {
            _context = context;
            IEmployee = employeeData;
            ICustomer = customerData;
            IPizza = pizzaData;
            IIngredient = ingredients;
            IAuth = authData;
            IStorageData = storage;
            IPizzaActualData = pizzaActual;
            IOrders = order;
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
