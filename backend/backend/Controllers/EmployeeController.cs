using AutoMapper;
using backend.Data;
using backend.Data.EmployeeRepo;
using backend.DTO;
using backend.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly DatabaseContext context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EmployeeController(DatabaseContext database, IUnitOfWork unitOfWork , IMapper mapper)
        {
            context = database;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task <IActionResult> GetAllEmployees([FromQuery] PaginatedList filter)
        {
            var validFilter = new PaginatedList(filter.PageNumber, filter.PageSize);
            var pagedData = await context.Employees
                                        .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                                        .Take(validFilter.PageSize)
                                        .ToListAsync();
            var totalRecords = await context.Employees.CountAsync();
            return Ok(new PagedResponse<List<Employee>>(pagedData, validFilter.PageNumber, validFilter.PageSize));
            //var employees = await _unitOfWork.IEmployee.GetEmployees();
            //return Ok(employees);
        }

        [HttpGet]
        [Route ("{id}")]
        public IActionResult GetById([FromRoute] long id)
        {
            var employee = _unitOfWork.IEmployee.GetEmployee(id);

            if (employee != null)
            {
                return Ok(employee);
            }

            return NotFound($"Employee with id: {id} not found" );
        }

        [HttpPost]
        public async Task<IActionResult> PostEmployee([FromBody] AddEmployeeDTO employeeDTO)
        {
            if (ModelState.IsValid)
            {
                var added = _mapper.Map<Employee>(employeeDTO);

                await _unitOfWork.IEmployee.AddEmployee(added);
                await _unitOfWork.Complete();

                return Ok(added);
            }

            return BadRequest("Invalid info");
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] long id, [FromBody] AddEmployeeDTO employeeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid info");
            }

            var oldOne = _unitOfWork.IEmployee.GetEmployee(id);
            if(oldOne == null)
            {
                return NotFound("Employee with this id not found");
            }
            _mapper.Map<AddEmployeeDTO, Employee>(employeeDTO, oldOne);

            await _unitOfWork.Complete();
            return Ok("Successfully updated!");
        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] long id)
        {
            var employee =  _unitOfWork.IEmployee.GetEmployee(id);
            if (employee == null)
            {
                return NotFound($"Employee with id: {id} not found");
            }
            _unitOfWork.IEmployee.DeleteEmployee(employee);
            await _unitOfWork.Complete();

            return Ok("Successfully deleted!");
        }

    }
}