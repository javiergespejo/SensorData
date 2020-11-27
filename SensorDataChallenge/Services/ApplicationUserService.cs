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
        private readonly IAccountRepository _accountRepository;
        private readonly IApplicationUserRepository _applicationUserRepository;

        public ApplicationUserService(IUnitOfWork unitOfWork, IMapper mapper, IAccountRepository accountRepository, IApplicationUserRepository applicationUserRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _accountRepository = accountRepository;
            _applicationUserRepository = applicationUserRepository;
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

        public ApplicationUser RegisterDTOToEntity(RegisterDTO registerDto)
        {
            var user = _mapper.Map<ApplicationUser>(registerDto);
            return user;
        }

        public RegisterDTO EntityToRegisterDTO(ApplicationUser user)
        {
            var registerDto = _mapper.Map<RegisterDTO>(user);
            return registerDto;
        }

        public async Task<ApplicationUser> GetUserById(string id)
        {
            var user = await _unitOfWork.ApplicationUserRepository.GetByIdAsync(id);
            return user;
        }

        public async Task<bool> UserExist(ApplicationUser user)
        {
            var userExist = await _unitOfWork.ApplicationUserRepository.UserExist(user);
            return userExist;
        }

        public async Task AddAndSave(ApplicationUser user)
        {
            _unitOfWork.ApplicationUserRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAndSave(ApplicationUser user)
        {
            _unitOfWork.ApplicationUserRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAndSave(string id)
        {
            _unitOfWork.ApplicationUserRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<Permission>> Permissions(RegisterDTO registerDto)
        {
            var users = await _accountRepository.Permissions(registerDto);
            return users;
        }

        public async Task<List<Permission>> GetPermissions()
        {
            var users = await _accountRepository.GetPermissions();
            return users;
        }

        public async Task UpdateClient(string id, RegisterDTO registerDto)
        {
            var user = _mapper.Map<ApplicationUser>(registerDto);
            var currentUser = await _applicationUserRepository.EditMethod(id);
            currentUser.ClientId = user.ClientId;
            currentUser.Email = user.Email;
            currentUser.Permission = user.Permission;
            currentUser.UserName = user.UserName;
            currentUser.Description = user.Description;
            await _applicationUserRepository.UpdateUser(currentUser);
        }
    }
}
