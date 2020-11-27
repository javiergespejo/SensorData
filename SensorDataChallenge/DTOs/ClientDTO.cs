using SensorDataChallenge.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SensorDataChallenge.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Business Name")]
        public string BusinessName { get; set; }
        [Required]
        [Display(Name = "RUC Number")]
        public int RucNum { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Display(Name = "Postal Code")]
        [DataType(DataType.PostalCode)]
        public int PostalCode { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public string Fax { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Web { get; set; }
        public List<UruguayTransit> UruguayTransit { get; set; }
        public List<UruguayLooseCargoTransit> UruguayLooseCargoTransit { get; set; }
        public List<Zone> Zone { get; set; }
        public bool IsActive { get; set; }
    }
}
