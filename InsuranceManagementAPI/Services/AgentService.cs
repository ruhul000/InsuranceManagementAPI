using InsuranceManagementAPI.Data.Repository;
using InsuranceManagementAPI.Models.Factories;
using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Services
{
    public class AgentService:IAgentService
    {
        private readonly IAgentRepository _agentRepository;
        private readonly IAgentFactory _agentFactory;

        public AgentService(IAgentRepository agentRepository, IAgentFactory agentFactory)
        {
            _agentRepository = agentRepository;
            _agentFactory = agentFactory;
        }
        public async Task<Agent> Create(Agent agent)
        {
            Agent? response = null;
            var agentDto = _agentFactory.CreateFrom(agent);

            try
            {
                var insertedId = _agentRepository.Add(agentDto).Result;
                if (insertedId == 0)
                {
                    return response;
                }


                //agentDto.DepKey = insertedId;

                response = _agentFactory.CreateFrom(agentDto);
            }
            catch (Exception ex)
            {
                return response;
            }

            return response;
        }

        public Task<bool> Delete(int AgentKey)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Agent>> GetAll()
        {
            var agentDtos = await _agentRepository.GetAll();

            return _agentFactory.CreateMultipleFrom(agentDtos);
        }

        public async Task<IEnumerable<Agent>> GetAllByBranch(int branchKey)
        {
            var agentDtos = await _agentRepository.GetAllByBranch(branchKey);

            return _agentFactory.CreateMultipleFrom(agentDtos);
        }

        public async Task<Agent> GetById(int AgentKey)
        {
            var agentDto = await _agentRepository.GetByID(AgentKey);

            return _agentFactory.CreateFrom(agentDto);
        }

        public Task<Agent> Update(Agent agent)
        {
            Agent? response = null;
            var agentDto = _agentFactory.CreateFrom(agent);

            try
            {
                var result = _agentRepository.Update(agentDto).Result;
                if (!result)
                {
                    return Task.FromResult<Agent>(response);
                }



                response = _agentFactory.CreateFrom(agentDto);
            }
            catch (Exception ex)
            {
                return Task.FromResult<Agent>(response);
            }

            return Task.FromResult(response);

        }
    }
}
