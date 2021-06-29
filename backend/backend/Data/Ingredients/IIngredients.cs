using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.Ingredients
{
    public interface IIngredients
    {
        public Task<List<Ingredient>> GetIngredients();
        public Task<Ingredient> GetIngredient(long id);
        public Task<bool> AddIngredient(Ingredient ingredient);
        public bool DeleteIngredient(Ingredient ingredient);
        public bool EditIngredient(Ingredient ingredient);
    }
}
