using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceManagementAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}")]
    [ApiVersion("1.0")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [MapToApiVersion("1.0")]
        [HttpGet("Clients")]
        public ActionResult<IEnumerable<Client>> GetAllClients()
        {
            IEnumerable<Client> response;
            try
            {
                response = _clientService.GetAllClients().Result;

                if (response == null || !response.Any())
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
        [HttpPost("Create")]
        public ActionResult<Client> CreateClient(Client client) 
        {
            Client? response;
            try
            {
                response = _clientService.Create(client).Result;

                if (response == null)
                {
                    return BadRequest("Client creation failed!");
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
