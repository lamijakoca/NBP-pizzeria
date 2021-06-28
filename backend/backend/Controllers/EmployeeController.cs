using AutoMapper;
using backend.Data;
using backend.Data.EmployeeRepo;
using backend.DTO;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EmployeeController(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task <IActionResult> GetAllEmployees()
        {
            var employees = await _unitOfWork.IEmployee.GetEmployees();

            return Ok(employees);
        }

    }
}
