 using AutoMapper;
using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace InsuranceManagementAPI.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly PolicyDBContext _context;
        public UserRepository(PolicyDBContext context) {
            _context = context;
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<UserDto> GetById(int id)
        {
            UserDto userDto = await _context.Users.FirstOrDefaultAsync(obj => obj.UserId == id);
            userDto.Password = "";
            return userDto;
        }
        public async Task<UserDto> GetByUserName(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(obj => obj.UserName == username || obj.Email == username);
        }
        public async Task<bool> Add(UserDto userDto)
        {
            _context.Users.Add(userDto);
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
