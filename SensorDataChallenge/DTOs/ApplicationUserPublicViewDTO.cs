using SensorDataChallenge.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
