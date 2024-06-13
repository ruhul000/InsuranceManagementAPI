using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceManagementAPI.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/MediclaimTariff")]
    [ApiVersion("1.0")]
    public class MediclaimTariffController : ControllerBase
    {
        private readonly IMediclaimTariffService _mediclaimTariffService;
        public MediclaimTariffController(IMediclaimTariffService mediclaimTariffService)
        {
            _mediclaimTariffService = mediclaimTariffService;
        }


        [MapToApiVersion("1.0")]
        [HttpPost("GetTravelRate")]
        
        public ActionResult<IEnumerable<MediclaimTariff>> GetTravelRate(MediclaimTariff mediclaimTariff)
        {

            IEnumerable<MediclaimTariff> response;
            try
            {
                response = _mediclaimTariffService.GetTravelRate(mediclaimTariff.Days_From, mediclaimTariff.Age_From,mediclaimTariff.Tariff_Type, mediclaimTariff.Travel_Type).Result;

                if (response == null || !response.Any())
                {
                    response = new List<MediclaimTariff>();
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
