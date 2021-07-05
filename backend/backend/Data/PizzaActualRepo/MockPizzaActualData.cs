using backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.PizzaActualRepo
{
    public class MockPizzaActualData : IPizzaActualData
    {
        public readonly DatabaseContext databaseContext;
        public MockPizzaActualData(DatabaseContext context)
        {
            databaseContext = context;
        }
        public async Task<bool> AddPizzaActual(CustomerPizzaActuals customerPizzaActuals)
        {
            await databaseContext.PizzaActuals.AddAsync(customerPizzaActuals);
            databaseContext.SaveChanges();
            return true;
        }

        public bool DeletePizzaActual(CustomerPizzaActuals customerPizzaActualst)
        {
            databaseContext.PizzaActuals.Remove(customerPizzaActualst);
            return true;
        }

        public bool EditPizzaActual(CustomerPizzaActuals customerPizzaActuals)
        {
             databaseContext.PizzaActuals.Update(customerPizzaActuals);
            return true;
        }

        public async Task<CustomerPizzaActuals> GetPizzaActual(long id)
        {
            return await databaseContext.PizzaActuals.FindAsync(id);
        }

        public async Task<List<CustomerPizzaActuals>> GetPizzaActuals()
        {
            return await databaseContext.PizzaActuals.ToListAsync();
        }
    }
}
