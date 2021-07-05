using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace backend.Data.HelpRepo
{
    public class MockOrders : IOrders
    {
        public readonly DatabaseContext databaseContext;
        public MockOrders(DatabaseContext context)
        {
            databaseContext = context;
        }

        public async Task<bool> AddOrder(Orders orders)
        {
            await databaseContext.Orders.AddAsync(orders);
            return true;
        }

        public bool DeleteOrder(Orders orders)
        {
            databaseContext.Orders.Remove(orders);
            return true;
        }

        public async Task<Orders> GetOrder(int id)
        {
            return await databaseContext.Orders.FindAsync(id);
        }

        public async Task<List<Orders>> GetOrders()
        {
            return await databaseContext.Orders.ToListAsync();
        }
    }
}
