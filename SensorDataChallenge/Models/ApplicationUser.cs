using Microsoft.AspNetCore.Identity;
using SensorDataChallenge.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SensorDataChallenge.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public Client Client { get; set; }
        public List<Permission> Permission { get; set; }
    }
}
