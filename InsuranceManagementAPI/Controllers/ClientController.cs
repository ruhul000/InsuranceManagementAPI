using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InsuranceManagementAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/Client")]
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
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                // or
                //identity.FindFirst("").Value;
            }

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
        [HttpPost("search")]
        public ActionResult<IEnumerable<Client>> GetAllClientsByName(Client client)
        {
            //searchWord = searchWord.Replace("~", "/");
            IEnumerable<Client> response;
            try
            {
                response = _clientService.GetAllClientsByName(client).Result;

                if (response == null || !response.Any())
                {
                    response = new List<Client>();
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        
        [MapToApiVersion("1.0")]
        [HttpGet("{clientKey}")]
        public ActionResult<Client> GetClientByID(long clientKey)
        {
           Client? response;
            try
            {
                response = _clientService.GetClientById(clientKey).Result;

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

        
        [MapToApiVersion("1.0")]
        [HttpPut("Update")]
        public ActionResult<Client> UpdateClient(Client client)
        {
            Client? response;
            try
            {
                response = _clientService.UpdateClient(client).Result;

                if (response == null)
                {
                    return BadRequest("Client update failed!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);

        }

        
        [MapToApiVersion("1.0")]
        [HttpDelete("Delete")]
        public ActionResult DeleteClient(long clientKey) 
        {
            bool deleted;
            try
            {
                deleted = _clientService.DeleteClient(clientKey).Result;

                if (!deleted)
                {
                    return BadRequest("Client deleted failed!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(deleted);
        }

    }
}
