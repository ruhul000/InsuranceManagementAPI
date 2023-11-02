using InsuranceManagementAPI.Data.Models;

namespace InsuranceManagementAPI.Data.Repository
{
    public interface IAgentRepository
    {
        Task<IEnumerable<AgentDto>> GetAll();
        Task<AgentDto> GetByID(int AgentKey);
        Task<int> Add(AgentDto agentDto);
        Task<bool> Update(AgentDto agentDto);
        Task<bool> Remove(int AgentKey);
    }
}
