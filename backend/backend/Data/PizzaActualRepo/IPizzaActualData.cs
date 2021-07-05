using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.PizzaActualRepo
{
    public interface IPizzaActualData
    {
        public Task<List<CustomerPizzaActuals>> GetPizzaActuals();
        public Task<CustomerPizzaActuals> GetPizzaActual(long id);
        public Task<bool> AddPizzaActual(CustomerPizzaActuals customerPizzaActuals);
        public bool DeletePizzaActual(CustomerPizzaActuals customerPizzaActualst);
        public bool EditPizzaActual(CustomerPizzaActuals customerPizzaActuals);
    }
}
