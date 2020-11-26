using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SensorDataChallenge.Models
{
    public class Permission
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}