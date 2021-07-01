using backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.StorageRepo
{
    public class MockStorageData : IStorageData
    {
        public readonly DatabaseContext databaseContext;
        public MockStorageData(DatabaseContext dbContext)
        {
            databaseContext = dbContext;
        }
        public async Task<bool> AddStorage(Storage storage)
        {
            await databaseContext.Storages.AddAsync(storage);
            databaseContext.SaveChanges();
            return true;
        }

        public bool DeleteStorage(Storage storage)
        {
            databaseContext.Storages.Remove(storage);
            return true;
        }

        public async Task<Storage> GetStorage(int id)
        {
            return await databaseContext.Storages.FindAsync(id);
        }

        public async Task<List<Storage>> GetStorages()
        {
            return await databaseContext.Storages.ToListAsync();
        }
    }
}
