using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtrack.Domain.Entities;

namespace Wirtrack.Application.Interfaces
{
    public interface ITripsServices
    {
        Task<List<Trips>> GetAll();
        Task<List<TripsJoinedDTO>> GetAllJoin();
        Task<Trips> GetById(int id);
        Task<bool> Delete(Trips trip);
        Task<Trips> Insert(TripsInsertUpdateDTO tripsCreateDto);
        Task<Trips> Update(int id, TripsInsertUpdateDTO tripsUpdateDTO);
    }
}
