using Azure.Core;
using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Data.Repository;
using InsuranceManagementAPI.Helper;
using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Models.Factories;
using System.Security.Cryptography;

namespace InsuranceManagementAPI.Services
{
    public class UserService : IUserService
    {
        private const int SALTLENGTH = 32;

        private readonly IUserFactory _userFactory;
        private readonly IUserRepository _userRepository;
        private readonly IEncryptionService _encryptionService;
        public UserService(IUserRepository userRepository, IUserFactory userFactory, IEncryptionService encryptionService) {
            _userRepository = userRepository;
            _userFactory = userFactory;
            _encryptionService = encryptionService; 
        }

        public async Task<UserResponse> Registration(UserRequest userRequest)
        {
            UserResponse response = new UserResponse();

            var salt = _encryptionService.GenerateSalt();
            var passwordHash = _encryptionService.EncryptPassword(userRequest.Password, salt);

            User user = new User
            {
                FullName = userRequest.FullName,
                UserName = userRequest.Username,
                Email = userRequest.Email,
                Password = passwordHash,
                Salt = salt,
                IsActive = true
            };

            UserDto userDto = _userFactory.CreateFrom(user);

            if(!_userRepository.Add(userDto).Result)
            {
                return response;
            }

            await _userRepository.GetById(userDto.UserId);

            return _userFactory.CreateResponseFrom(userDto);

        }
    }
}
