using AutoMapper;
using SensorDataChallenge.DTOs;
using SensorDataChallenge.Models;

namespace SensorDataChallenge.Mappings
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            //CreateMap<Entity, EntityDTO>().ReverseMap();

            // Client
            CreateMap<Client, ClientDTO>().ReverseMap();

            // User
            CreateMap<ApplicationUser, ApplicationUserDTO>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserLoginDTO>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserPublicViewDTO>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserEditDTO>().ReverseMap();
        }
    }
}
