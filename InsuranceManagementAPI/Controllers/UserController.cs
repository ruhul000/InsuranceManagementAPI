using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace InsuranceManagementAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/User")]
    [ApiVersion("1.0")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;            
        }

        [EnableCors("Policy")]
        [HttpPost("Register")]
        [MapToApiVersion("1.0")]
        public ActionResult<UserResponse> Registration(UserRequest userRequest)
        {
            UserResponse? response;
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

        [EnableCors("Policy")]
        [HttpPost("Login")]
        [MapToApiVersion("1.0")]
        public ActionResult<AuthInformation> UserLogin(UserLoginRequest userLoginRequest)
        {
            AuthInformation response;
            try
            {
                response = _userService.UserLogin(userLoginRequest).Result;

                if (response.Token.IsNullOrEmpty() && response.RefreshToken.IsNullOrEmpty())
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        [EnableCors("Policy")]
        [HttpPost("Refresh")]
        [MapToApiVersion("1.0")]
        public ActionResult<AuthInformation> RefreshToken(AuthInformation authInfo)
        {
            AuthInformation response;
            try
            {
                response = _userService.RefreshToken(authInfo).Result;

                if (response.Token.IsNullOrEmpty() && response.RefreshToken.IsNullOrEmpty())
                {
                    return Unauthorized();
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
