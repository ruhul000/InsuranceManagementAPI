using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Models.Factories
{
    public interface IClientFactory
    {
        IEnumerable<Client> CreateMultipleFrom(IEnumerable<ClientDto> clientDtos);

        Client CreateFrom(ClientDto clientDto);
        ClientDto CreateFrom(Client client);
    }
}
