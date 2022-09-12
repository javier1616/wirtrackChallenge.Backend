using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Wirtrack.Application.Interfaces;
using Wirtrack.Domain.Entities;

namespace Wirtrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehiclesServices _service;
        public VehiclesController(IVehiclesServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicles()
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
        public async Task<IActionResult> CreateVehicle([FromBody] VehiclesInsertUpdateDTO vehicleCreateDTO)
        {
            try
            {
                var vehicleCreated = await _service.Insert(vehicleCreateDTO);
                return Ok(vehicleCreated);
            }
            catch (System.Exception err)
            {
                return NotFound(err.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveVehicle([FromQuery(Name = "id")] int id)
        {
            try
            {
                var vehicle = await _service.GetById(id);
                if (vehicle != null)
                {
                    var flag = await _service.Delete(vehicle);
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
        public async Task<IActionResult> UpdateVehicle([FromRoute] int id, [FromBody] VehiclesInsertUpdateDTO vehicleUpdateDTO)
        {
            try
            {
                var vehicle = await _service.GetById(id);
                if (vehicle != null)
                {
                    var flag = await _service.Update(id, vehicleUpdateDTO);
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
        public async Task<IActionResult> GetVehicleById([FromQuery(Name = "id")] int id)
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
