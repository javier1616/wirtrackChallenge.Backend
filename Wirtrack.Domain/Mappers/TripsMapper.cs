

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
                IdStatus = tripsInsertDTO.IdStatus,
                IsDeleted = tripsInsertDTO.IsDeleted,
                DateTrip = tripsInsertDTO.DateTrip,
                LastModified = DateTime.UtcNow
            };
   
            return trip;
        }

        public Trips UpdateTripsFromTripsInsertUpdateDTO(Trips trip, TripsInsertUpdateDTO tripsInsertDTO)
        {
            trip.IdDestinationCity = tripsInsertDTO.IdCity;
            trip.IdVehicle = tripsInsertDTO.IdVehicle;
            trip.IdStatus = tripsInsertDTO.IdStatus;
            trip.IsDeleted = tripsInsertDTO.IsDeleted;
            trip.DateTrip = tripsInsertDTO.DateTrip;
            trip.LastModified = DateTime.UtcNow;            

            return trip;
        }


    }
}
