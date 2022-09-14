using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using Wirtrack.Application.Interfaces;
using Wirtrack.Domain.Entities;

namespace Wirtrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly ITripsServices _service;
        public TripsController(ITripsServices service)
        {
            _service = service;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetTripById([FromQuery(Name = "id")]int id)
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

        [HttpGet]
        public async Task<IActionResult> GetAllTrips()
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
        public async Task<IActionResult> CreateTrip([FromBody] TripsInsertUpdateDTO tripCreateDTO)
        {
            try
            {
                var tripCreated = await _service.Insert(tripCreateDTO);
                return Ok(tripCreated);
            }
            catch (System.Exception err)
            {
                return NotFound(err.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveTrip([FromQuery(Name = "id")] int id)
        { 
            try
            {
                var trip = await _service.GetById(id);
                if (trip != null)
                {
                    var flag = await _service.Delete(trip);

                    //string jsonstr = "{ \"result\" : \""+flag.ToString()+"\"}";

                    //JObject json = JObject.Parse(jsonstr);

                    return Ok(trip);
                    //return Ok(flag);
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

        [HttpPut("id")]
        public async Task<IActionResult> UpdateTrip([FromQuery(Name = "id")] int id, [FromBody] TripsInsertUpdateDTO tripUpdateDTO)
        {
            try
            {
                var trip = await _service.GetById(id);
                if (trip != null)
                {
                    var flag = await _service.Update(id, tripUpdateDTO);
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

        [HttpGet("join")]
        public async Task<IActionResult> GetAllTripsJoin()
        {
            try
            {
                var test = await _service.GetAllJoin();

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
