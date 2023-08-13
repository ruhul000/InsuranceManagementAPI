using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Helper;

namespace InsuranceManagementAPI.Models.Factories
{
    public class ClientFactory : IClientFactory
    {
        IMappingFactory<Client> _clientFactory;
        IMappingFactory<ClientDto> _clientDtoFactory;
        public ClientFactory(IMappingFactory<Client> clientFactory, IMappingFactory<ClientDto> clientDtoFactory) 
        {
            _clientFactory = clientFactory;
            _clientDtoFactory = clientDtoFactory;
        }

        public IEnumerable<Client> CreateMultipleFrom(IEnumerable<ClientDto> clientDtos) 
        { 
            IEnumerable<Client> clients = _clientFactory.CreateMultipleFrom(clientDtos);
            return clients;
        }

        public Client CreateFrom(ClientDto clientDto)
        {
            return _clientFactory.CreateFrom(clientDto);
        }
        public ClientDto CreateFrom(Client client)
        {
            return _clientDtoFactory.CreateFrom(client);
        }
    }
}
