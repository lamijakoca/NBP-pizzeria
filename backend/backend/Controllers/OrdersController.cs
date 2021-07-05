using AutoMapper;
using backend.Data;
using backend.DTO;
using backend.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public readonly IMapper mapper;
        public readonly IUnitOfWork unitOfWork;
        public OrdersController(IMapper _mapper, IUnitOfWork _unit)
        {
            mapper = _mapper;
            unitOfWork = _unit;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await unitOfWork.IOrders.GetOrders();
            return Ok(orders);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var order = await unitOfWork.IOrders.GetOrder(id);
            if (order == null)
            {
                return NotFound($"Order with id: {id} not found");
            }
            return Ok(order);
        }
        [HttpPost]
        public async Task<IActionResult> AddPizza([FromBody] AddOrder order)
        {
            if (ModelState.IsValid)
            {
                //int IngredientId = Int32.Parse(User.FindFirst(""))
                var added = mapper.Map<Orders>(order);


                await unitOfWork.IOrders.AddOrder(added);
                await unitOfWork.Complete();

                return Ok(added);
            }

            return BadRequest("Invalid info");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletePizza([FromRoute] int id)
        {
            var order = await unitOfWork.IOrders.GetOrder(id);
            if (order == null)
            {
                return NotFound("Order does not exist");
            }
            unitOfWork.IOrders.DeleteOrder(order);
            await unitOfWork.Complete();
            return Ok("Successfully deleted!");
        }
    }
}
