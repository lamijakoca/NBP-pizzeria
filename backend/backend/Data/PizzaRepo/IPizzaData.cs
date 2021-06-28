using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.PizzaRepo
{
    public interface IPizzaData
    {
        public Task<List<Pizza>> GetPizzas();
        public Task<Pizza> GetPizza(long id);
        public Task<bool> AddPizza(Pizza pizza);
        public bool DeletePizza(Pizza pizza);
        public bool UpdatePizza(Pizza pizza);
    }
}
