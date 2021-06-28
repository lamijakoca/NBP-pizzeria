using AutoMapper;
using backend.Data;
using backend.DTO;
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
    public class CustomerController : Controller
    {
        public IUnitOfWork unitOfWork;
        public IMapper mapper;

        public CustomerController(IUnitOfWork _unit, IMapper _mapper)
        {
            unitOfWork = _unit;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await unitOfWork.ICustomer.GetCustomers();
            return Ok(customers);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCustomer([FromRoute] long id)
        {
            var customer = await unitOfWork.ICustomer.GetCustomer(id);
            if (customer != null)
            {
                return Ok(customer);
            }
            return NotFound($"Customer with id: {id} not found");
        }
        [HttpPost]
        public async Task<IActionResult> PostCustomer ([FromBody] CustomerDTO customerDTO)
        {
            if (ModelState.IsValid)
            {
                var added = mapper.Map<Customer>(customerDTO);

                await unitOfWork.ICustomer.AddCustomer(added);
                await unitOfWork.Complete();

                return Ok(added);
            }

            return BadRequest("Invalid info");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] long id)
        {
            var user = await unitOfWork.ICustomer.GetCustomer(id);
            if (user == null)
            {
                return NotFound($"Customer with id: {id} not found");
            }
            unitOfWork.ICustomer.DeleteCustomer(user);
            await unitOfWork.Complete();

            return Ok("Successfully deleted!");
        }
    }
}
