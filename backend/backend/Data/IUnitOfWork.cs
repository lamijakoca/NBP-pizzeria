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
    public interface IUnitOfWork
    {
        public IEmployeeData IEmployee { get; set; }
        public ICustomerData ICustomer { get; set; }
        public IPizzaData IPizza { get; set; }
        public IIngredients IIngredient { get; set; }
        public IAuthData IAuth { get; set; }
        public IStorageData IStorageData { get; set; }
        public IPizzaActualData IPizzaActualData { get; set; }
        public IOrders IOrders { get; set; }
        Task<bool> Complete();
    }
}
