using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceManagementAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/MotorTariff")]
    [ApiVersion("1.0")]
    public class MotorTariffController : ControllerBase
    {
        private readonly IMotorTariffService _motorTariffService;
        public MotorTariffController(IMotorTariffService motorTariffService)
        {
            _motorTariffService = motorTariffService;
        }

        [MapToApiVersion("1.0")]
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<MotorTariff>> GetAll()
        {

            IEnumerable<MotorTariff> response;
            try
            {
                response = _motorTariffService.GetAll().Result;

                if (response == null || !response.Any())
                {
                    response = new List<MotorTariff>();
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
