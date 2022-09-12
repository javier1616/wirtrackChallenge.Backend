using System;
using System.ComponentModel.DataAnnotations;

namespace Wirtrack.Domain.Entities
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime LastModified { get; set; } = DateTime.UtcNow;

        [Required]
        public bool IsDeleted { get; set; } = false;

        
    }
}
