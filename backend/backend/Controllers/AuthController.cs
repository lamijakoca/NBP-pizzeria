using backend.Data.AuthRepo;
using backend.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthData authData;
        public AuthController(IAuthData data)
        {
            authData = data;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] AuthEmployee authEmployee)
        {
            var token = await authData.Authenticate(authEmployee.Username, authEmployee.Password);

            if(token != null)
                return Ok($"Bearer {token}");
            return Unauthorized("Unauthorized!");
        }
    }
}
