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
    public class StorageController : Controller
    {
        public readonly IUnitOfWork unitOfWork;
        public readonly IMapper mapper;
        public StorageController(IUnitOfWork _unit, IMapper _mapper)
        {
            unitOfWork = _unit;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetStorages()
        {
            var storages = await unitOfWork.IStorageData.GetStorages();
            return Ok(storages);
        }

        [HttpPost]
        public async Task<IActionResult> PostStorage([FromBody] StorageDTO storage)
        {
            if (ModelState.IsValid)
            {
                var added = mapper.Map<Storage>(storage);

                await unitOfWork.IStorageData.AddStorage(added);
                await unitOfWork.Complete();

                return Ok(added);
            }

            return BadRequest("Invalid info");
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            var storage = await unitOfWork.IStorageData.GetStorage(id);
            if (storage == null)
            {
                return NotFound($"Customer with id: {id} not found");
            }
            unitOfWork.IStorageData.DeleteStorage(storage);
            await unitOfWork.Complete();

            return Ok("Successfully deleted!");
        }
    }
}
