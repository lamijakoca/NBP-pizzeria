using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.AuthRepo
{
    public interface IAuthData
    {
        public Task<string> AuthenticateEmployee(string username, string password);
        public Task<string> AuthenticateCustomer(string username, string password);
    }
}
