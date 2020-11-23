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
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserDTO>().ReverseMap();
        }
    }
}
