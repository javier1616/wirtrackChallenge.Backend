

using System;
using Wirtrack.Domain.Entities;

namespace Wirtrack.Domain.Mapper
{
    public class VehiclesMapper
    {
        public Vehicles FromVehiclesInsertUpdateDTOToVehicles(VehiclesInsertUpdateDTO vehiclesInsertDTO)
        {
            var vehicle = new Vehicles
            {
                Type = vehiclesInsertDTO.Type,
                CarLicense = vehiclesInsertDTO.CarLicense,
                Model = vehiclesInsertDTO.Model
            };
   
            return vehicle;
        }

        public Vehicles UpdateVehiclesFromVehiclesInsertUpdateDTO(Vehicles vehicle, VehiclesInsertUpdateDTO vehicleInsertDTO)
        {

            vehicle.Type = vehicleInsertDTO.Type;
            vehicle.CarLicense = vehicleInsertDTO.CarLicense;
            vehicle.Model = vehicleInsertDTO.Model;

            return vehicle;
        }


    }
}
