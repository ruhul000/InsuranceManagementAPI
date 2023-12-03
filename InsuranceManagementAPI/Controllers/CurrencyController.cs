using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceManagementAPI.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/Currency")]
    [ApiVersion("1.0")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;
        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }


        
        [MapToApiVersion("1.0")]
        [HttpPost("Create")]
        public ActionResult<Currency> Create(Currency currency)
        {

            Currency? response;
            try
            {
                response = _currencyService.Create(currency).Result;

                if (response == null)
                {
                    return BadRequest("Currency creation failed!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        
        [MapToApiVersion("1.0")]
        [HttpGet("Currencies")]
        public ActionResult<IEnumerable<Currency>> GetAll()
        {

            IEnumerable<Currency> response;
            try
            {
                response = _currencyService.GetAll().Result;

                if (response == null || !response.Any())
                {
                    response = new List<Currency>();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        
        [MapToApiVersion("1.0")]
        [HttpGet("{CurrencyKey}")]
        public ActionResult<Currency> GetByID(int CurrencyKey)
        {
            Currency? response;
            try
            {
                response = _currencyService.GetById(CurrencyKey).Result;

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
        public ActionResult<Currency> Update(Currency currency)
        {
            Currency? response;
            try
            {
                response = _currencyService.Update(currency).Result;

                if (response == null)
                {
                    return BadRequest("Currency update failed!");
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
