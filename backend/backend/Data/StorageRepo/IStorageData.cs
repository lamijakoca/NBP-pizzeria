using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.StorageRepo
{
    public interface IStorageData
    {
        public Task<bool> AddStorage(Storage storage);
        public bool DeleteStorage(Storage storage);
        public Task<List<Storage>> GetStorages();
        public Task<Storage> GetStorage(int id);
    }
}
