using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Wirtrack.Application.Interfaces;
using Wirtrack.Domain.Command;
using Wirtrack.Domain.Entities;
using Wirtrack.Domain.Mapper;
using Wirtrack.Domain.Queries;

namespace Wirtrack.Application.Services
{
    public class OpenWeathermapServices : IOpenWeathermapServices
    {

        private readonly IGenericsRepository _repository;
        private readonly ICitiesQueries _citiesQueries;

        public OpenWeathermapServices(IGenericsRepository repository, ICitiesQueries citiesQueries)
        {
            _citiesQueries = citiesQueries;
            _repository = repository;
        }

        //public async Task<List<CitiesWeatherDTO>> GetWeatherForAllCities()
        public CitiesWeatherDTO GetWeather(Cities city)
        {
            string url = "https://api.openweathermap.org/data/2.5/weather?q=" + city.Name + "," + city.CountryCode + "&appid=97a225f282a08fa4337a7a119d6a9300";
            WebRequest webRequest = WebRequest.Create(url);
            HttpWebResponse httpWebResponse = null;
            httpWebResponse = (HttpWebResponse) webRequest.GetResponse();

            string result = string.Empty;

            using (Stream stream = httpWebResponse.GetResponseStream())
            {
                StreamReader streamReader = new StreamReader(stream);
                result = streamReader.ReadToEnd();
                streamReader.Close();
            }

            JObject json = JObject.Parse(result);
            var weather = json.SelectToken("weather")[0];
            var weatherValue = weather.SelectToken("main").ToString();

            CitiesWeatherDTO cityWeather = new CitiesWeatherDTO
            {
                Id = city.Id,
                Name = city.Name,
                CountryCode = city.CountryCode,
                LastModified = city.LastModified,
                IsDeleted = city.IsDeleted,
                WeatherCondition = weatherValue
            };            

            return cityWeather;
        }

        public async Task<List<Cities>> GetAll()
        {
            var cities = await _citiesQueries.GetAll();

            return cities;
        }

        public async Task<CitiesWeatherDTO> GetWeatherForCityById(int id)
        {
            CitiesWeatherDTO citiesWeather;
            var city = await _citiesQueries.GetById(id);

            citiesWeather = this.GetWeather(city);

            return citiesWeather;
        }

        public async Task<Cities> Insert(CitiesInsertUpdateDTO cityInsertDTO)
        {

            var citiesMapper = new CitiesMapper();

            var city = citiesMapper.FromCitiesInsertUpdateDTOToCities(cityInsertDTO);

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

        public async Task<Cities> GetById(int id)
        {
            var city = await _citiesQueries.GetById(id);

            return city;
        }
    }
}
