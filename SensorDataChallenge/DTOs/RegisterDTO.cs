using Microsoft.AspNetCore.Mvc;
using SensorDataChallenge.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SensorDataChallenge.DTOs
{
    public class RegisterDTO
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Remote(action: "IsUserNameInUse", controller: "Account")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public int ClientId { get; set; }
        public List<int> PermissionsId { get; set; }
        public List<Permission> Permission { get; set; }

    }
}
