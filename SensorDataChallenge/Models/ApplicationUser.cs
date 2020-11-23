using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SensorDataChallenge.Models
{
    public class ApplicationUser : BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public Client Client { get; set; }
        public enum PermissionEnum
        {
            ViewUsers, // Permission to view users in the system
            PostUser, // Permission to register a user in the system
            PutUser, // Permission to modify a user in the system
            DeleteUser, // Permission to unsubscribe a user from the system
            ViewClients, // Permission to view clients in the system
            PostClient, // Permission to register a client in the system
            PutClient, // Permission to modify a client in the system
            DeleteClient, // Permission to remove a client from the system
            ViewMap  // Permission to view the map
        }
        public List<PermissionEnum> Permission { get; set; }
    }
}
