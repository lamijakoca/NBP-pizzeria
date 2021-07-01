using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.PizzaActualRepo
{
    public interface IPizzaActualData
    {
        public Task<List<PizzaActual>> GetPizzaActuals();

        public Task<PizzaActual> GetPizzaActual(long Id);
        public Task<bool> AddPizzaActual(PizzaActual pizzaActual);
        public bool DeletePizzaActual(PizzaActual pizzaActual);
        public bool EditPizzaActual (PizzaActual pizzaActual);
    }
}
