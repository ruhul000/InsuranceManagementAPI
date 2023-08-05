using Azure.Core;
using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Data.Repository;
using InsuranceManagementAPI.Helper;
using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Models.Factories;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace InsuranceManagementAPI.Services
{
    public class UserService : IUserService
    {
        private const int SALTLENGTH = 32;

        private readonly IUserFactory _userFactory;
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authenticationService;
        public UserService(IUserRepository userRepository, IUserFactory userFactory, IAuthenticationService authenticationService) {
            _userRepository = userRepository;
            _userFactory = userFactory;
            _authenticationService = authenticationService; 
        }

        public async Task<UserResponse> Registration(UserRequest userRequest)
        {
            UserResponse? response = null;

            var userDto = _userRepository.GetByUserName(userRequest.UserName).Result;
            
            if (userDto != null) return response;

            var salt = _authenticationService.GenerateSalt();
            var passwordHash = _authenticationService.EncryptPassword(userRequest.Password, salt);

            User user = new User
            {
                FullName = userRequest.FullName,
                UserName = userRequest.UserName,
                Email = userRequest.Email,
                Password = passwordHash,
                Salt = salt,
                IsActive = true
            };

            userDto = _userFactory.CreateFrom(user);

            if(!_userRepository.Add(userDto).Result)
            {
                return response;
            }

            await _userRepository.GetById(userDto.UserId);

            return _userFactory.CreateResponseFrom(userDto);

        }

        public async Task<AuthResponse> UserLogin(UserLoginRequest loginRequest)
        {
            AuthResponse authResponse = new AuthResponse();

            User user = VerifyUser(loginRequest);

            if (user == null) return authResponse;

            authResponse.Token = _authenticationService.GenerateJWT(user);

            return authResponse;
        }

        private User VerifyUser(UserLoginRequest loginRequest)
        {
            User? response = null;

            var userDto = _userRepository.GetByUserName(loginRequest.UserName).Result;

            if (userDto == null) return response;

            var passwordHash = _authenticationService.EncryptPassword(loginRequest.Password, userDto.Salt);

            if(passwordHash.Equals(userDto.Password) && userDto.IsActive == true)
            {
                response = _userFactory.CreateFrom(userDto);
            }

            return response;
        }
    }
}
