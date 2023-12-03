using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceManagementAPI.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/Agent")]
    [ApiVersion("1.0")]
    public class AgentController : ControllerBase
    {
        private readonly IAgentService _agentService;
        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }


        
        [MapToApiVersion("1.0")]
        [HttpPost("Create")]
        public ActionResult<Agent> Create(Agent Agent)
        {

            Agent? response;
            try
            {
                response = _agentService.Create(Agent).Result;

                if (response == null)
                {
                    return BadRequest("Agent creation failed!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        
        [MapToApiVersion("1.0")]
        [HttpGet("Agents")]
        public ActionResult<IEnumerable<Agent>> GetAll()
        {

            IEnumerable<Agent> response;
            try
            {
                response = _agentService.GetAll().Result;

                if (response == null || !response.Any())
                {
                    response = new List<Agent>();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        
        [MapToApiVersion("1.0")]
        [HttpGet("{AgentKey}")]
        public ActionResult<Agent> GetByID(int AgentKey)
        {
            Agent? response;
            try
            {
                response = _agentService.GetById(AgentKey).Result;

                if (response == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        
        [MapToApiVersion("1.0")]
        [HttpPut("Update")]
        public ActionResult<Agent> Update(Agent agent)
        {
            Agent? response;
            try
            {
                response = _agentService.Update(agent).Result;

                if (response == null)
                {
                    return BadRequest("Agent update failed!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);

        }
    }
}
