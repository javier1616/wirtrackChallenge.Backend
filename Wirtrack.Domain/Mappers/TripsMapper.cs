

using System;
using Wirtrack.Domain.Entities;

namespace Wirtrack.Domain.Mapper
{
    public class TripsMapper
    {
        public Trips FromTripsInsertUpdateDTOToTrips(TripsInsertUpdateDTO tripsInsertDTO)
        {
            var trip = new Trips
            {
                IdDestinationCity = tripsInsertDTO.IdCity,
                IdVehicle = tripsInsertDTO.IdVehicle,
                IdStatus = tripsInsertDTO.IdStatus
            };
   
            return trip;
        }

        public Trips UpdateTripsFromTripsInsertUpdateDTO(Trips trip, TripsInsertUpdateDTO tripsInsertDTO)
        {

            trip.IdDestinationCity = tripsInsertDTO.IdCity;
            trip.IdVehicle = tripsInsertDTO.IdVehicle;
            trip.IdStatus = tripsInsertDTO.IdStatus;
            trip.LastModified = DateTime.UtcNow;            

            return trip;
        }


    }
}
