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

        public async Task<IEnumerable<Client>> GetAllClientsByName(Client client)
        {
            ClientDto clientDto = _clientFactory.CreateFrom(client);
            var clientDtos = await _clientRepository.GetAllClientsByName(clientDto);

            return _clientFactory.CreateMultipleFrom(clientDtos);
        }
        public async Task<Client> GetClientById(long clientKey)
        {
            var clientDto = await _clientRepository.GetClientByID(clientKey);

            return _clientFactory.CreateFrom(clientDto);
        }
        public async Task<Client?> Create (Client client)
        {
            Client? response = null;
            var clientDto = _clientFactory.CreateFrom(client);
            
            try
            {
                var insertedId = _clientRepository.Add(clientDto).Result;
                if (insertedId==0)
                {
                    return response;
                }

                clientDto = await _clientRepository.GetClientByID(insertedId);

                response = _clientFactory.CreateFrom(clientDto);
            }
            catch (Exception ex)
            {
                return response;
            }

            return response;
        }
        public async Task<Client?> UpdateClient(Client client)
        {
            Client? response = null;
            var clientDto = _clientFactory.CreateFrom(client);

            try
            {
                var result = _clientRepository.Update(clientDto).Result;
                if (!result)
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
        public async Task<bool> DeleteClient(long clientKey)
        {
            var deleted = false;
            try
            {
                deleted = await _clientRepository.Remove(clientKey);
                if (deleted)
                {
                    return deleted;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return deleted;
        }
    }
}
