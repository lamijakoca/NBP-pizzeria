using AutoMapper;
using backend.Data;
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
        [Route("{name}")]
        public async Task<IActionResult> GetIngredientById([FromRoute] string name)
        {
            var ingredient = await unitOfWork.IIngredient.GetIngredient(name);
            if (ingredient == null)
            {
                return NotFound($"Ingredient with name: {name} not found.");
            }
            return Ok(ingredient);
        }
    }
}
