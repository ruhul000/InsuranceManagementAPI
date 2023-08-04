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
        private readonly IMapper _mapper;
        public UserRepository(PolicyDBContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<UserDto> GetById(int id)
        {
            return await _context.Users.FirstAsync(obj => obj.UserId == id);
        }
        public async Task<bool> Add(UserDto userDto)
        {
            _context.Users.Add(userDto);
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
