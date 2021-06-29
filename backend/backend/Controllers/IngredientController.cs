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
    public class IngredientController : ControllerBase
    {
        public readonly IUnitOfWork unitOfWork;
        public readonly IMapper mapper;
        public IngredientController(IUnitOfWork _unit, IMapper _mapper)
        {
            unitOfWork = _unit;
            mapper = _mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllIngredients()
        {
            var ingredients = await unitOfWork.IIngredient.GetIngredients();
            return Ok(ingredients);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetIngredientById([FromRoute] long id)
        {
            var ingredient = await unitOfWork.IIngredient.GetIngredient(id);
            if (ingredient == null)
            {
                return NotFound($"Ingredient with id: {id} not found.");
            }
            return Ok(ingredient);
        }

        [HttpPost]
        public async Task<IActionResult> AddIngredient([FromBody] IngredientDTO ingredientDTO)
        {
            if (ModelState.IsValid)
            {
                var added = mapper.Map<Ingredient>(ingredientDTO);

                await unitOfWork.IIngredient.AddIngredient(added);
                await unitOfWork.Complete();

                return Ok("Successfully inserted!");
            }
            return BadRequest("Invalid info");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteByName([FromRoute] long id)
        {
            var thisOne = await unitOfWork.IIngredient.GetIngredient(id);
            if (thisOne == null)
            {
                return NotFound($"Ingredient with id {id} not found");
            }
            unitOfWork.IIngredient.DeleteIngredient(thisOne);
            await unitOfWork.Complete();

            return Ok("Successfully deleted!");
        }

        [HttpPut]
        [Route ("{id}")]
        public async Task<IActionResult> UpdateIngredient([FromRoute] long id, [FromBody] IngredientDTO ingredientDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid info");
            }
            var oldOne = await unitOfWork.IIngredient.GetIngredient(id);
            if (oldOne == null)
            {
                return NotFound($"There is no Ingredient with name: {id}");
            }
            mapper.Map<IngredientDTO, Ingredient>(ingredientDTO, oldOne);

            await unitOfWork.Complete();
            return Ok("Successfully updated!");
        }
    }
}
