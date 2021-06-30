using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace backend.Data.AuthRepo
{
    public class MockAuthData : IAuthData
    {
        private readonly DatabaseContext databaseContext;
        public MockAuthData(DatabaseContext context)
        {
            databaseContext = context;
        }

        public async Task<string> AuthenticateCustomer(string username, string password)
        {
            var customer = await databaseContext.Customers.FirstOrDefaultAsync(c => c.Username == username && c.Password == password);
            if (customer != null)
            {
                var key = "SomethinUnusual andqwnf8392bgf8293bgbvwenvign32";

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes(key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("Id", customer.Id.ToString()),
                        new Claim("Username", customer.Username)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(tokenKey),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            return null;
        }

        public async Task<string> AuthenticateEmployee(string username, string password)
        {
            var employee = await databaseContext.Employees.FirstOrDefaultAsync(e => e.Username == username && e.Password == password);

            if(employee != null)
            {
                var key = "SomethinUnusual andqwnf8392bgf8293bgbvwenvign32";

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes(key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("Id", employee.Id.ToString()),
                        new Claim("Username", employee.Username),
                        new Claim("Type", employee.Type)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(tokenKey), 
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            return null;
        }
    }
}
