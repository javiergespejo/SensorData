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
