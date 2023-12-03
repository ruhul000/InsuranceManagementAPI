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

        
        [MapToApiVersion("1.0")]
        [HttpPost("ItemNames")]
        public ActionResult<IEnumerable<MarineCargoTariff>> GetItemNames(MarineCargoTariff marineCargoTariff)
        {

            IEnumerable<MarineCargoTariff> response;
            try
            {
                response = _marineCargoTariffService.GetItemNames(marineCargoTariff.Tariff_Catagory,marineCargoTariff.TypeOfRisk).Result;

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

        
        [MapToApiVersion("1.0")]
        [HttpPost("TypeA")]
        public ActionResult<IEnumerable<MarineCargoTariff>> GetTypeA(MarineCargoTariff marineCargoTariff)
        {

            IEnumerable<MarineCargoTariff> response;
            try
            {
                response = _marineCargoTariffService.GetTypeA(marineCargoTariff.Tariff_Catagory, marineCargoTariff.TypeOfRisk, marineCargoTariff.ItemName).Result;

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

        
        [MapToApiVersion("1.0")]
        [HttpPost("TypeB")]
        public ActionResult<IEnumerable<MarineCargoTariff>> GetTypeB(MarineCargoTariff marineCargoTariff)
        {

            IEnumerable<MarineCargoTariff> response;
            try
            {
                response = _marineCargoTariffService.GetTypeB(marineCargoTariff.Tariff_Catagory, marineCargoTariff.TypeOfRisk, marineCargoTariff.ItemName,marineCargoTariff.TypeA).Result;

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

        
        [MapToApiVersion("1.0")]
        [HttpPost("TypeC")]
        public ActionResult<IEnumerable<MarineCargoTariff>> GetTypeC(MarineCargoTariff marineCargoTariff)
        {

            IEnumerable<MarineCargoTariff> response;
            try
            {
                response = _marineCargoTariffService.GetTypeC(marineCargoTariff.Tariff_Catagory, marineCargoTariff.TypeOfRisk, marineCargoTariff.ItemName, marineCargoTariff.TypeA, marineCargoTariff.TypeB).Result;

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

        
        [MapToApiVersion("1.0")]
        [HttpPost("Rate")]
        public ActionResult<IEnumerable<MarineCargoTariff>> GetRate(MarineCargoTariff marineCargoTariff)
        {

            IEnumerable<MarineCargoTariff> response;
            try
            {
                response = _marineCargoTariffService.GetRate(marineCargoTariff.Tariff_Catagory, marineCargoTariff.TypeOfRisk, marineCargoTariff.ItemName, marineCargoTariff.TypeA, marineCargoTariff.TypeB,marineCargoTariff.TypeC).Result;

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
