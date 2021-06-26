using backend.Data.EmployeeRepo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeData employeeData;
        public EmployeeController(IEmployeeData employee)
        {
            employeeData = employee;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(employeeData.GetEmployees());
        }
    }
}
