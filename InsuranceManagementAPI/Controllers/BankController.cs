using InsuranceManagementAPI.Data;
using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankController : ControllerBase
    {
        private readonly IBankService _bankService;
        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }
        [HttpGet("")]
        public async Task<ActionResult> GetAllBanks()
        {
            IEnumerable<Bank> response;
            try
            {
                response = await _bankService.GetAllBanks();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return Ok(response);
        }
    }
}
