﻿using backend.Data.AuthRepo;
using backend.Data.CustomerRepo;
using backend.Data.EmployeeRepo;
using backend.Data.Ingredients;
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
        public IIngredients IIngredient { get; set; }
        public IAuthData IAuth { get; set; }
        public MockUnitOfWork(
            DatabaseContext context, 
            IEmployeeData employeeData, 
            ICustomerData customerData, 
            IPizzaData pizzaData,
            IIngredients ingredients,
            IAuthData authData)
        {
            _context = context;
            IEmployee = employeeData;
            ICustomer = customerData;
            IPizza = pizzaData;
            IIngredient = ingredients;
            IAuth = authData;
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
