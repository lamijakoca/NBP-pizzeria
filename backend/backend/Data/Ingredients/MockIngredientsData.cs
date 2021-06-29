using backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.Ingredients
{
    public class MockIngredientsData : IIngredients
    {
        private readonly DatabaseContext databaseContext;
        public MockIngredientsData(DatabaseContext database)
        {
            databaseContext = database;
        }
        public async Task<bool> AddIngredient(Ingredient ingredient)
        {
            await databaseContext.Ingredients.AddAsync(ingredient);
            return true;
        }

        public bool DeleteIngredient(Ingredient ingredient)
        {
            databaseContext.Ingredients.Remove(ingredient);
            return true;
        }

        public bool EditIngredient(Ingredient ingredient)
        {
            databaseContext.Ingredients.Update(ingredient);
            return true;
        }

        public async Task<List<Ingredient>> GetIngredients()
        {
            return await databaseContext.Ingredients.ToListAsync();
        }

        public async Task<Ingredient> GetIngredient(long id)
        {
            return await databaseContext.Ingredients.FindAsync(id);
        }
    }
}
