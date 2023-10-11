using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAllClients();

        Task<IEnumerable<Client>> GetAllClientsByName(String searchWord);
        Task<Client> GetClientById(long clientKey);
        Task<Client> Create(Client client);
        Task<Client?> UpdateClient(Client client);
        Task<bool> DeleteClient(long clientKey);
    }
}
