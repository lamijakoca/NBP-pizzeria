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
        private readonly DatabaseContext databaseContext;
        public MockPizzaActualData(DatabaseContext database)
        {
            databaseContext = database;
        }
        public async Task<bool> AddPizzaActual(PizzaActual pizzaActual)
        {
            await databaseContext.PizzaActuals.AddAsync(pizzaActual);
            databaseContext.SaveChanges();
            return true;
        }

        public bool DeletePizzaActual(PizzaActual pizzaActual)
        {
            databaseContext.PizzaActuals.Remove(pizzaActual);
            return true;
        }

        public bool EditPizzaActual(PizzaActual pizzaActual)
        {
            databaseContext.PizzaActuals.Update(pizzaActual);
            return true;
        }

        public async Task<PizzaActual> GetPizzaActual(long Id)
        {
            return await databaseContext.PizzaActuals.FindAsync(Id);
        }

        public async Task<List<PizzaActual>> GetPizzaActuals()
        {
            return await databaseContext.PizzaActuals.ToListAsync();
        }
    }
}
