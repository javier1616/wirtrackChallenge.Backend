using System;

namespace Wirtrack.Domain.Entities
{
    public class TripsInsertUpdateDTO : Entity
    {
        public int IdCity { get; set; }

        public int IdVehicle { get; set; }

        public DateTime DateTrip { get; set; }

        public int IdStatus { get; set; }
    }
}
