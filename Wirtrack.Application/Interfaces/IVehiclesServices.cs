using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtrack.Domain.Entities;

namespace Wirtrack.Application.Interfaces
{
    public interface IVehiclesServices
    {
        Task<List<Vehicles>> GetAll();
        Task<Vehicles> GetById(int id);
        Task<bool> Delete(Vehicles trip);
        Task<Vehicles> Insert(VehiclesInsertUpdateDTO vehicleCreateDto);
        Task<Vehicles> Update(int id, VehiclesInsertUpdateDTO vehicleUpdateDTO);

    }
}
