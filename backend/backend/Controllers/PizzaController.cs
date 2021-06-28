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
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : Controller
    {
        public readonly IUnitOfWork unitOfWork;
        public readonly IMapper mapper;

        public PizzaController(IUnitOfWork _unit, IMapper _mapper)
        {
            unitOfWork = _unit;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pizzas = await unitOfWork.IPizza.GetPizzas();
            return Ok(pizzas);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            var pizza = await unitOfWork.IPizza.GetPizza(id);
            if (pizza == null)
            {
                return NotFound($"Pizza with id: {id} not found");
            }
            return Ok(pizza);
        }

        [HttpPost]
        public async Task<IActionResult> AddPizza([FromBody] PizzaDTO pizzaDTO)
        {
            if (ModelState.IsValid)
            {
                var added = mapper.Map<Pizza>(pizzaDTO);

                await unitOfWork.IPizza.AddPizza(added);
                await unitOfWork.Complete();

                return Ok(added);
            }

            return BadRequest("Invalid info");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletePizza([FromRoute]long id)
        {
            var pizza = await unitOfWork.IPizza.GetPizza(id);
            if (pizza == null)
            {
                return NotFound("Pizza does not exist");
            }
            unitOfWork.IPizza.DeletePizza(pizza);
            await unitOfWork.Complete();
            return Ok("Successfully deleted!");
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdatePizza([FromRoute] long id, [FromBody] PizzaDTO pizzaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid info");
            }

            var oldOne = await unitOfWork.IPizza.GetPizza(id);
            if (oldOne == null)
            {
                return NotFound("Pizza with this id not found");
            }
            mapper.Map<PizzaDTO, Pizza>(pizzaDTO, oldOne);

            await unitOfWork.Complete();
            return Ok("Successfully updated!");
        }
    }
}