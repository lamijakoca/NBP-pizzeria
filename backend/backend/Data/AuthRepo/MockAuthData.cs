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
        public async Task<string> Authenticate(string username, string password)
        {
            var employee = await databaseContext.Employees.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);

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
