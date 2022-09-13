using System;

namespace Wirtrack.Domain.Entities
{
    public class TripsJoinedDTO : Entity
    {
        public string Destination { get; set; }
        public string Vehicle { get; set; }
        public DateTime DateTrip { get; set; }
        public string WeatherConditions { get; set; }
        public string VehicleType { get; set; }
        public string CarLicense { get; set; }
        public int IdStatus { get; set; }
    }
}
