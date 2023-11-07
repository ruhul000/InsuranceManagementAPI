using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceManagementAPI.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/MarineCargoTariff")]
    [ApiVersion("1.0")]
    public class MarineCargoTariffController : ControllerBase
    {
        private readonly IMarineCargoTariffService _marineCargoTariffService;
        public MarineCargoTariffController(IMarineCargoTariffService marineCargoTariffService)
        {
            _marineCargoTariffService = marineCargoTariffService;
        }

        [EnableCors("Policy")]
        [MapToApiVersion("1.0")]
        [HttpGet("Category")]
        public ActionResult<IEnumerable<MarineCargoTariff>> GetAll()
        {

            IEnumerable<MarineCargoTariff> response;
            try
            {
                response = _marineCargoTariffService.GetTariffCategories().Result;

                if (response == null || !response.Any())
                {
                    response = new List<MarineCargoTariff>();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        [EnableCors("Policy")]
        [MapToApiVersion("1.0")]
        [HttpGet("ItemName/{TariffCategory}/{RiskType}")]
        public ActionResult<IEnumerable<MarineCargoTariff>> GetItemNames(String TariffCategory, String RiskType)
        {

            IEnumerable<MarineCargoTariff> response;
            try
            {
                response = _marineCargoTariffService.GetItemNames(TariffCategory,RiskType).Result;

                if (response == null || !response.Any())
                {
                    response = new List<MarineCargoTariff>();
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
