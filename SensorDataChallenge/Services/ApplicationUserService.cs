using AutoMapper;
using SensorDataChallenge.DTOs;
using SensorDataChallenge.Interfaces;
using SensorDataChallenge.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SensorDataChallenge.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ApplicationUserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ApplicationUserPublicViewDTO>> GetAllUsers()
        {
            var users = await _unitOfWork.ApplicationUserRepository.GetAllAsync();
            var usersDto = _mapper.Map<List<ApplicationUserPublicViewDTO>>(users);
            return usersDto;
        }

        public ApplicationUser EntityDTOToEntity(ApplicationUserDTO userDto)
        {
            var user = _mapper.Map<ApplicationUser>(userDto);
            return user;
        }

        public ApplicationUserDTO EntityToEntityDTO(ApplicationUser user)
        {
            var userDto = _mapper.Map<ApplicationUserDTO>(user);
            return userDto;
        }

        public ApplicationUserPublicViewDTO EntityToEntityPublicViewDTO(ApplicationUser user)
        {
            var userDto = _mapper.Map<ApplicationUserPublicViewDTO>(user);
            return userDto;
        }

        public async Task<ApplicationUser> GetUserById(int id)
        {
            var user = await _unitOfWork.ApplicationUserRepository.GetByIdAsync(id);
            return user;
        }

        public async Task<bool> UserExist(ApplicationUser user)
        {
            var userExist = await _unitOfWork.ApplicationUserRepository.UserExist(user);
            return userExist;
        }

        public void AddAndSave(ApplicationUser user)
        {
            _unitOfWork.ApplicationUserRepository.Add(user);
            _unitOfWork.SaveChangesAsync();
        }

        public void UpdateAndSave(ApplicationUser user)
        {
            _unitOfWork.ApplicationUserRepository.Update(user);
            _unitOfWork.SaveChangesAsync();
        }

        public void DeleteAndSave(int id)
        {
            _unitOfWork.ApplicationUserRepository.DeleteAsync(id);
            _unitOfWork.SaveChangesAsync();
        }
    }
}
