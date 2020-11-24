using SensorDataChallenge.Models;
using System.Collections.Generic;

namespace SensorDataChallenge.DTOs
{
    public class ApplicationUserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Client Client { get; set; }
        public List<Permission> Permission { get; set; }
    }
}
