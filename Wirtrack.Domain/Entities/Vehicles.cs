using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Wirtrack.Domain.Entities
{
    public class Vehicles : Entity
    {
        [Required]
        public string Type { get; set; }

        [Required]
        [MaxLength(50)]
        public string CarLicense { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        public ICollection<Trips> Trips { get; set; }
    }
}
