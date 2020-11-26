using Microsoft.AspNetCore.Identity;
using SensorDataChallenge.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SensorDataChallenge.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public List<Permission> Permission { get; set; }
    }
}
