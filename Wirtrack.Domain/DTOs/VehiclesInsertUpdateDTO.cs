using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Wirtrack.Domain.Entities
{
    public class VehiclesInsertUpdateDTO : Entity
    {
  
        public string Type { get; set; }

        public string CarLicense { get; set; }

        public string Model { get; set; }

    }
}
