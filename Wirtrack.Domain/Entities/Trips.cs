using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wirtrack.Domain.Entities
{
    public class Trips : Entity
    {

        [Required]
        public int IdDestinationCity { get; set; }
        [ForeignKey("IdDestinationCity")]
        public Cities Cities { get; set; }

        [Required]
        public int IdVehicle { get; set; }
        [ForeignKey("IdVehicle")]
        public Vehicles Vehicle { get; set; }

        [Required]
        public DateTime DateTrip { get; set; }

        [Required]
        public int IdStatus { get; set; }
    }
}
