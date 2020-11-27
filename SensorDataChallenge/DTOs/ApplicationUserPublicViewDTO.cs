using SensorDataChallenge.Models;
using System.ComponentModel.DataAnnotations;

namespace SensorDataChallenge.DTOs
{
    public class ApplicationUserPublicViewDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Username")]
        public string UserName { get; set; }
        public Client Client { get; set; }
    }
}
