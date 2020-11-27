using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SensorDataChallenge.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required]
        public string BusinessName { get; set; }
        [Required]
        public int RucNum { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [DataType(DataType.PostalCode)]
        public int PostalCode { get; set; }
        public List<Zone> Zone { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public string Fax { get; set; }
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Web { get; set; }
        public List<UruguayTransit> UruguayTransit { get; set; }
        public List<UruguayLooseCargoTransit> UruguayLooseCargoTransit { get; set; }
        public bool IsActive { get; set; }
    }
}
