

using System;
using Wirtrack.Domain.Entities;

namespace Wirtrack.Domain.Mapper
{
    public class CitiesMapper
    {
        public Cities FromCitiesInsertUpdateDTOToCities(CitiesInsertUpdateDTO citiesInsertDTO)
        {
            var city = new Cities
            {
                Name = citiesInsertDTO.Name,
                CountryCode = citiesInsertDTO.CountryCode,
                WeatherCondition = citiesInsertDTO.WeatherCondition
            };
   
            return city;
        }

        public Cities UpdateCitiesFromCitiesInsertUpdateDTO(Cities city, CitiesInsertUpdateDTO cityInsertDTO)
        {

            city.Name = cityInsertDTO.Name;
            city.CountryCode = cityInsertDTO.CountryCode;
            city.WeatherCondition = cityInsertDTO.WeatherCondition;

            return city;
        }

        public CitiesInsertUpdateDTO UpdateFromCitiesWeatherToCitiesInsertUpdateDTO(CitiesWeatherDTO cityWeather)
        {
            CitiesInsertUpdateDTO cityInsertUpdate = new CitiesInsertUpdateDTO
            {
                Id = cityWeather.Id,
                Name = cityWeather.Name,
                CountryCode = cityWeather.CountryCode,
                WeatherCondition = cityWeather.WeatherCondition,
                IsDeleted = cityWeather.IsDeleted,
                LastModified = cityWeather.LastModified
            };

            return cityInsertUpdate;

        }


    }
}
