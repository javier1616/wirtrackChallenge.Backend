using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtrack.Domain.Entities;

namespace Wirtrack.Application.Interfaces
{
    public interface ICitiesServices
    {
        Task<List<Cities>> GetAll();
        Task<Cities> GetById(int id);
        Task<bool> Delete(Cities trip);
        Task<Cities> Insert(CitiesInsertUpdateDTO cityCreateDto);
        Task<Cities> Update(int id, CitiesInsertUpdateDTO cityUpdateDTO);

    }
}
