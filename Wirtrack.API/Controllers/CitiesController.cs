using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Wirtrack.Application.Interfaces;
using Wirtrack.Domain.Entities;

namespace Wirtrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICitiesServices _service;
        public CitiesController(ICitiesServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            try
            {
                var test = await _service.GetAll();

                if (test != null)
                {
                    return Ok(test);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateCity([FromBody] CitiesInsertUpdateDTO cityCreateDTO)
        {
            try
            {
                var cityCreated = await _service.Insert(cityCreateDTO);
                return Ok(cityCreated);
            }
            catch (System.Exception err)
            {
                return NotFound(err.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCity([FromQuery(Name = "id")] int id)
        {
            try
            {
                var city = await _service.GetById(id);
                if (city != null)
                {
                    var flag = await _service.Delete(city);
                    return Ok(flag);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCity([FromRoute] int id, [FromBody] CitiesInsertUpdateDTO cityUpdateDTO)
        {
            try
            {
                var city = await _service.GetById(id);
                if (city != null)
                {
                    var flag = await _service.Update(id, cityUpdateDTO);
                    return Ok(flag);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetCityById([FromQuery(Name = "id")] int id)
        {
            try
            {
                var test = await _service.GetById(id);

                if (test != null)
                {
                    return Ok(test);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }
    }
}
