using SensorDataChallenge.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SensorDataChallenge.DTOs
{
    public class ApplicationUserDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public Client Client { get; set; }
        public List<Permission> Permission { get; set; }
    }
}
