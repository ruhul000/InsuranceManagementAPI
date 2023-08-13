using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Data.Repository;
using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Models.Factories;
using System.Collections;

namespace InsuranceManagementAPI.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientFactory _clientFactory;
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientFactory clientFactory, IClientRepository clientRepository)
        {
            _clientFactory = clientFactory;
            _clientRepository = clientRepository;
        }
        public async Task<IEnumerable<Client>> GetAllClients()
        {
            var clientDtos = await _clientRepository.GetAllClients();

            return _clientFactory.CreateMultipleFrom(clientDtos);
        }
        public async Task<Client?> Create (Client client)
        {
            Client? response = null;
            var clientDto = _clientFactory.CreateFrom(client);
            
            try
            {
                if (!_clientRepository.Add(clientDto).Result)
                {
                    return response;
                }

                clientDto = await _clientRepository.GetClientByID(clientDto.ClientKey);

                response = _clientFactory.CreateFrom(clientDto);
            }
            catch (Exception ex)
            {
                return response;
            }

            return response;
        }
    }
}
