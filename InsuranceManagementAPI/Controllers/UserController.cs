using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceManagementAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}")]
    [ApiVersion("1.0")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;            
        }

        [HttpPost("Register")]
        [MapToApiVersion("1.0")]
        public ActionResult<UserResponse> Registration(UserRequest userRequest)
        {
            UserResponse response;
            try
            {
                response = _userService.Registration(userRequest).Result;

                if (response == null)
                {
                    return BadRequest("User registration failed!");
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
