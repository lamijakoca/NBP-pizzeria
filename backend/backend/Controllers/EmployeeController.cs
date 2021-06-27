using backend.Data.EmployeeRepo;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeData employeeData;
        public EmployeeController(IEmployeeData employee)
        {
            employeeData = employee;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(employeeData.GetEmployees());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Employee employee)
        {
            if (ModelState.IsValid)
            {
                await employeeData.AddEmployee(employee);
                return Ok("Uspesno registrovano u bazi");
            }
            else
                return BadRequest("Proveri unete podatke, molim te");
        }
    }
}
