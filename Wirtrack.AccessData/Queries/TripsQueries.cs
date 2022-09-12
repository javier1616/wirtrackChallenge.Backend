using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wirtrack.Domain.Entities;
using Wirtrack.Domain.Queries;
namespace Wirtrack.AccessData.Queries
{
    public class TripsQueries : ITripsQueries
    {

        private readonly WirtrackContext _context;

        public TripsQueries(WirtrackContext context)
        {
            _context = context;
        }

        public async Task<List<Trips>> GetAll()
        {

            var trips = await _context.Set<Trips>().ToListAsync();

            return trips;
        }

        public async Task<Trips> GetById(int tripId)
        {

            var trip = await _context.Set<Trips>().Where(t => t.Id == tripId).FirstOrDefaultAsync();

            return trip;

        }

        public async Task<List<TripsJoinedDTO>> GetAllJoin()
        {

            List<TripsJoinedDTO> tripsJoinedDTO = new List<TripsJoinedDTO>();

            var tripsJoined =  await (from t in _context.Trips
                                join v in _context.Vehicles on t.IdVehicle equals v.Id
                                join c in _context.Cities on t.IdDestinationCity equals c.Id
         
                               select new
                               {
                                   t.Id,
                                   t.DateTrip,
                                   Destination = (string)c.Name,
                                   Vehicle = (string)v.Model,
                                   WeatherCondition = (string)c.WeatherCondition,
                                   t.IdStatus
                               }).ToListAsync();


            foreach (var elem in tripsJoined)
            {
                TripsJoinedDTO trip = new TripsJoinedDTO
                {
                    Id = elem.Id,
                    DateTrip = elem.DateTrip,
                    Destination = elem.Destination,
                    IdStatus = elem.IdStatus,
                    Vehicle = elem.Vehicle,
                    WeatherConditions = elem.WeatherCondition
                };

                tripsJoinedDTO.Add(trip);
            }
                                 
            return tripsJoinedDTO;

        }

    }
}