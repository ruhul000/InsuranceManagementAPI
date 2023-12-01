using InsuranceManagementAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceManagementAPI.Data.Repository
{
    public class AgentRepository : IAgentRepository
    {
        private readonly PolicyDBContext _context;

        public AgentRepository(PolicyDBContext context)
        {
            _context = context;
        }
        public async Task<int> Add(AgentDto agentDto)
        {
            _context.Agent.Add(agentDto);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AgentDto>> GetAll()
        {
            return await _context.Agent.ToListAsync();
        }

        public async Task<IEnumerable<AgentDto>> GetAllByBranch(int branchKey)
        {
            return await _context.Agent.Where(a=> a.BranchKey == branchKey).OrderBy(a=>a.AgentName).ToListAsync();
        }

        public async Task<AgentDto> GetByID(int AgentKey)
        {
            return await _context.Agent.FirstOrDefaultAsync(obj => obj.AgentKey == AgentKey);
        }

        public async Task<bool> Update(AgentDto agentDto)
        {
            _context.Agent.Attach(agentDto);
            _context.Entry(agentDto).State = EntityState.Modified;
            return (await _context.SaveChangesAsync() > 0);
        }

        public Task<bool> Remove(int AgentKey)
        {
            throw new NotImplementedException();
        }
    }
}
