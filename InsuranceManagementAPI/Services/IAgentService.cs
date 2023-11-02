using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Services
{
    public interface IAgentService
    {
        Task<IEnumerable<Agent>> GetAll();
        Task<Agent> GetById(int AgentKey);
        Task<Agent> Create(Agent agent);
        Task<Agent> Update(Agent agent);
        Task<bool> Delete(int AgentKey);
    }
}
