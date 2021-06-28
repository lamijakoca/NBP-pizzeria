using backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.PizzaRepo
{
    public class MockPizzaData : IPizzaData
    {
        private readonly DatabaseContext databaseContext;
        public MockPizzaData(DatabaseContext context)
        {
            databaseContext = context;
        }
        public async Task<bool> AddPizza(Pizza pizza)
        {
            await databaseContext.Pizzas.AddAsync(pizza);
            return true;
        }

        public bool DeletePizza(Pizza pizza)
        {
            databaseContext.Pizzas.Remove(pizza);
            return true;
        }

        public async Task<Pizza> GetPizza(long id)
        {
            return await databaseContext.Pizzas.FindAsync(id);
        }

        public async Task<List<Pizza>> GetPizzas()
        {
            return await databaseContext.Pizzas.ToListAsync();
        }

        public bool UpdatePizza(Pizza pizza)
        {
            databaseContext.Pizzas.Update(pizza);
            return true;
        }
    }
}
