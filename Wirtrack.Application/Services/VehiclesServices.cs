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
    public class VehiclesServices : IVehiclesServices
    {

        private readonly IGenericsRepository _repository;
        private readonly IVehiclesQueries _vehiclesQueries;

        public VehiclesServices(IGenericsRepository repository, IVehiclesQueries vehiclesQueries)
        {
            _vehiclesQueries = vehiclesQueries;
            _repository = repository;
        }


        public async Task<List<Vehicles>> GetAll()
        {
            var vehicles = await _vehiclesQueries.GetAll();

            return vehicles;
        }

        public async Task<bool> Delete(Vehicles vehicle)
        {
            try
            {
                await _repository.Remove(vehicle);
                return true;
            }
            catch (System.Exception)
            {
                throw new Exception("Cannot delete Vehicle");
            }

        }

        public async Task<Vehicles> GetById(int id)
        {
            var vehicle = await _vehiclesQueries.GetById(id);

            return vehicle;
        }

        public async Task<Vehicles> Insert(VehiclesInsertUpdateDTO vehicleInsertDTO)
        {

            var vehiclesMapper = new VehiclesMapper();

            var vehicle = vehiclesMapper.FromVehiclesInsertUpdateDTOToVehicles(vehicleInsertDTO);

            await _repository.Add(vehicle);

            return vehicle;
        }

        public async Task<Vehicles> Update(int id, VehiclesInsertUpdateDTO vehicleInsertUpdateDTO)
        {
            var vehiclesMapper = new VehiclesMapper();

            var currentVehicle = await this.GetById(id);

            currentVehicle = vehiclesMapper.UpdateVehiclesFromVehiclesInsertUpdateDTO(currentVehicle, vehicleInsertUpdateDTO);

            await _repository.Update(currentVehicle);

            return currentVehicle;
        }

    }
}
