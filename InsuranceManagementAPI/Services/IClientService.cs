using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAllClients();
        Task<Client> Create(Client client);
    }
}
