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
    public class CitiesServices : ICitiesServices
    {

        private readonly IGenericsRepository _repository;
        private readonly ICitiesQueries _citiesQueries;
        private readonly IOpenWeathermapServices _openWeathermapServices;

        public CitiesServices(IGenericsRepository repository, ICitiesQueries citiesQueries, IOpenWeathermapServices openWeathermapServices)
        {
            _citiesQueries = citiesQueries;
            _repository = repository;
            _openWeathermapServices = openWeathermapServices;
        }


        public async Task<List<Cities>> GetAll()
        {
            var cities = await _citiesQueries.GetAll();

            return cities;
        }

        public async Task<bool> Delete(Cities city)
        {
            try
            {
                await _repository.Remove(city);
                return true;
            }
            catch (System.Exception)
            {
                throw new Exception("Cannot delete City");
            }

        }

        public async Task<Cities> GetById(int id)
        {
            var city = await _citiesQueries.GetById(id);

            return city;
        }

        public async Task<CitiesWeatherDTO> GetByIdWithWeather(int id)
        {
            var city = await _citiesQueries.GetById(id);

            CitiesWeatherDTO cityWeather = _openWeathermapServices.GetWeather(city);

            return cityWeather;
        }

        public async Task<Cities> Insert(CitiesInsertUpdateDTO cityInsertDTO)
        {

            var citiesMapper = new CitiesMapper();

            var city = citiesMapper.FromCitiesInsertUpdateDTOToCities(cityInsertDTO);

            CitiesWeatherDTO cityWeather = _openWeathermapServices.GetWeather(city);
            city.WeatherCondition = cityWeather.WeatherCondition;

            await _repository.Add(city);

            return city;
        }

        public async Task<Cities> Update(int id, CitiesInsertUpdateDTO cityInsertUpdateDTO)
        {
            var citiesMapper = new CitiesMapper();

            var currentCity = await this.GetById(id);

            currentCity = citiesMapper.UpdateCitiesFromCitiesInsertUpdateDTO(currentCity, cityInsertUpdateDTO);

            await _repository.Update(currentCity);

            return currentCity;
        }

        public async Task<bool> UpdateWeatherConditions()
        {
            List<Cities> listCities = await this.GetAll();

            if (listCities != null)
            {
                foreach (Cities elem in listCities)
                {
                    CitiesWeatherDTO cityWeather = new CitiesWeatherDTO();
                    CitiesInsertUpdateDTO cityUpdate = new CitiesInsertUpdateDTO();
                    var citiesMapper = new CitiesMapper();

                    cityWeather = await _openWeathermapServices.GetWeatherForCityById(elem.Id);

                    cityUpdate = citiesMapper.UpdateFromCitiesWeatherToCitiesInsertUpdateDTO(cityWeather);

                    var city = citiesMapper.UpdateCitiesFromCitiesInsertUpdateDTO(elem,cityUpdate);

                    await _repository.Update(city);
                }
                return true;
            }
            return false;
        }

    }
}
