using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.HelpRepo
{
    public interface IOrders
    {
        public Task<List<Orders>> GetOrders();
        public Task<Orders> GetOrder(int id);
        public Task<bool> AddOrder(Orders orders);
        public bool DeleteOrder(Orders orders);
    }
}
