using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Models.Factories
{
    public interface IAgentFactory
    {
        IEnumerable<AgentDto> CreateMultipleFrom(IEnumerable<Agent> agent);
        IEnumerable<Agent> CreateMultipleFrom(IEnumerable<AgentDto> agentDto);

        Agent CreateFrom(AgentDto agentDto);
        AgentDto CreateFrom(Agent agent);
    }
}
