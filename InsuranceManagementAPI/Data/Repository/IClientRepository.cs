using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Data.Repository
{
    public interface IClientRepository
    {
        Task<IEnumerable<ClientDto>> GetAllClients();
        Task<IEnumerable<ClientDto>> GetAllClientsByName(ClientDto clientDto);
        Task<ClientDto> GetClientByID(long id);
        Task<long> Add(ClientDto clientDto);
        Task<bool> Update(ClientDto client);
        Task<bool> Remove(long clientKey);
    }
}
