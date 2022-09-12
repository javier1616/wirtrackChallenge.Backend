using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Wirtrack.Domain.Entities
{
    public class Cities : Entity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string CountryCode { get; set; }

        public ICollection<Trips> Trips { get; set; }

    }
}
