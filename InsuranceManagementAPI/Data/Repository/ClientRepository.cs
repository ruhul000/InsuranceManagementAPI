using AutoMapper;
using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceManagementAPI.Data.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly PolicyDBContext _context;

        public ClientRepository(PolicyDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ClientDto>> GetAllClients()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<ClientDto> GetClientByID(long id)
        {
            return await _context.Clients.FirstOrDefaultAsync(obj => obj.ClientKey == id);
        }
        public async Task<bool> Add(ClientDto client)
        {
            _context.Clients.Add(client);
            return  (await _context.SaveChangesAsync() > 0) ;
        }
    }
}
