using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtrack.Application.Interfaces;
using Wirtrack.Domain.Command;
using Wirtrack.Domain.Entities;
using Wirtrack.Domain.Mapper;
using Wirtrack.Domain.Queries;

namespace Wirtrack.Application.Services
{
    public class TripsServices : ITripsServices
    {
        private readonly IGenericsRepository _repository;
        private readonly ITripsQueries _tripsQueries;
        

        public TripsServices(IGenericsRepository repository, ITripsQueries tripsQueries)
        {
            _repository = repository;
            _tripsQueries = tripsQueries;
        }


        public async Task<bool> Delete(Trips trip)
        {
            try
            {
                await _repository.Remove(trip);
                return true;
            }
            catch (System.Exception)
            {
                throw new Exception("Cannot delete Trip");
            }

        }

        public async Task<List<Trips>> GetAll()
        {
            var trips = await _tripsQueries.GetAll();

            return trips;
        }

        public async Task<Trips> GetById(int id)
        {
            var trip = await _tripsQueries.GetById(id);

            return trip;
        }

        public async Task<Trips> Insert(TripsInsertUpdateDTO tripInsertDTO)
        {

            var tripsMapper = new TripsMapper();

            var trips = tripsMapper.FromTripsInsertUpdateDTOToTrips(tripInsertDTO);
                       
            await _repository.Add(trips);

            return trips;
        }

        public async Task<Trips> Update(int id, TripsInsertUpdateDTO tripInsertUpdateDTO)
        {
            var tripsMapper = new TripsMapper();

            var currentTrip = await this.GetById(id);

            currentTrip = tripsMapper.UpdateTripsFromTripsInsertUpdateDTO(currentTrip, tripInsertUpdateDTO);

            await _repository.Update(currentTrip);

            return currentTrip;
        }

        public async Task<List<TripsJoinedDTO>> GetAllJoin()
        {
            var trips = await _tripsQueries.GetAllJoin();

            return trips;
        }

    }
}
