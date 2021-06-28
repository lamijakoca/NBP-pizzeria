using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.PizzaRepo
{
    public class MockPizzaData : IPizzaData
    {
        public Task<bool> AddPizza(Pizza pizza)
        {
            throw new NotImplementedException();
        }

        public bool DeletePizza()
        {
            throw new NotImplementedException();
        }

        public Task<Pizza> GetPizza()
        {
            throw new NotImplementedException();
        }

        public Task<List<Pizza>> GetPizzas()
        {
            throw new NotImplementedException();
        }

        public bool UpdatePizza()
        {
            throw new NotImplementedException();
        }
    }
}
