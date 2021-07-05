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
    public class PizzaActualController : ControllerBase
    {
        public IUnitOfWork unitOfWork;
        public IMapper mapper;
        public PizzaActualController(IUnitOfWork _unit, IMapper _mapper)
        {
            unitOfWork = _unit;
            mapper = _mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pizzas = await unitOfWork.IPizzaActualData.GetPizzaActuals();
            return Ok(pizzas);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            var pizza = await unitOfWork.IPizzaActualData.GetPizzaActual(id);
            if (pizza == null)
            {
                return NotFound($"Pizza with id: {id} not found.");
            }
            return Ok(pizza);
        }
        [HttpPost]
        public async Task<IActionResult> AddPizza([FromBody] PizzaActualDTO pizzaActualDTO)
        {
            if (ModelState.IsValid)
            {
                var added = mapper.Map<CustomerPizzaActuals>(pizzaActualDTO);

                await unitOfWork.IPizzaActualData.AddPizzaActual(added);
                await unitOfWork.Complete();

                return Ok(added);
            }

            return BadRequest("Invalid info");
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] long id)
        {
            var thisOne = await unitOfWork.IPizzaActualData.GetPizzaActual(id);
            if (thisOne == null)
            {
                return NotFound($"Pizza with id {id} not found");
            }
            unitOfWork.IPizzaActualData.DeletePizzaActual(thisOne);
            await unitOfWork.Complete();

            return Ok("Successfully deleted!");
        }

            [HttpPut]
            [Route("{id}")]
            public async Task<IActionResult> Update([FromRoute] long id, [FromBody] PizzaActualDTO pizzaActualDTO)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid info");
                }
                var oldOne = await unitOfWork.IPizzaActualData.GetPizzaActual(id);
                if (oldOne == null)
                {
                    return NotFound($"Not found pizza with id {id}");
                }
                mapper.Map<PizzaActualDTO, CustomerPizzaActuals>(pizzaActualDTO, oldOne);

                await unitOfWork.Complete();
                return Ok("Successfully updated!");
            }
    }
}
