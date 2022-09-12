

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
            };
   
            return city;
        }

        public Cities UpdateCitiesFromCitiesInsertUpdateDTO(Cities city, CitiesInsertUpdateDTO cityInsertDTO)
        {

            city.Name = cityInsertDTO.Name;
            city.CountryCode = cityInsertDTO.CountryCode;            

            return city;
        }


    }
}
