using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Helper;

namespace InsuranceManagementAPI.Models.Factories
{
    public class AgentFactory:IAgentFactory
    {
        IMappingFactory<Agent> _agentFactory;
        IMappingFactory<AgentDto> _agentDtoFactory;

        public AgentFactory(IMappingFactory<Agent> agentFactory, IMappingFactory<AgentDto> agentDtoFactory)
        {
            _agentFactory = agentFactory;
            _agentDtoFactory = agentDtoFactory;
        }

        public Agent CreateFrom(AgentDto agentDto)
        {
            Agent response = _agentFactory.CreateFrom(agentDto);
            return response;
        }

        public AgentDto CreateFrom(Agent agent)
        {
            AgentDto response = _agentDtoFactory.CreateFrom(agent);
            return response;
        }

        public IEnumerable<AgentDto> CreateMultipleFrom(IEnumerable<Agent> agent)
        {
            IEnumerable<AgentDto> response = _agentDtoFactory.CreateMultipleFrom(agent);
            return response;
        }

        public IEnumerable<Agent> CreateMultipleFrom(IEnumerable<AgentDto> agentDto)
        {
            IEnumerable<Agent> response = _agentFactory.CreateMultipleFrom(agentDto);
            return response;
        }
    }
}
