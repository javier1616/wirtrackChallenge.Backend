﻿using System;

namespace Wirtrack.Domain.Entities
{
    public class TripsJoinedDTO : Entity
    {
        public string Destination { get; set; }

        public string Vehicle { get; set; }

        public DateTime DateTrip { get; set; }

        public int IdStatus { get; set; }
    }
}
