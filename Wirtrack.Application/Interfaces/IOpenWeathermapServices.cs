using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtrack.Domain.Entities;

namespace Wirtrack.Application.Interfaces
{
    public interface IOpenWeathermapServices
    {
        public CitiesWeatherDTO GetWeather(Cities city);

        public Task<CitiesWeatherDTO> GetWeatherForCityById(int id);

        Task<List<Cities>> GetAll();
        Task<Cities> GetById(int id);
        Task<Cities> Insert(CitiesInsertUpdateDTO cityCreateDto);
        Task<Cities> Update(int id, CitiesInsertUpdateDTO cityUpdateDTO);

    }
}
