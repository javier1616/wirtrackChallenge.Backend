using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Wirtrack.Domain.Entities
{
    public class CitiesInsertUpdateDTO : Entity
    {
  
        public string Name { get; set; }

        public string CountryCode { get; set; }

        public string WeatherCondition { get; set; }

    }
}
