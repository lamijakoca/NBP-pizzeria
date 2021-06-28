﻿using AutoMapper;
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

        [HttpGet]
        [Route ("{id}")]
        public IActionResult GetById([FromRoute] long id)
        {
            var employee = _unitOfWork.IEmployee.GetEmployee(id);

            if (employee != null)
            {
                return Ok(employee);
            }

            return NotFound(new { Message = $"Employee with id: {id} not found" });
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

    }
}
