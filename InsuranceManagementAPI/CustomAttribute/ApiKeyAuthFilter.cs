using InsuranceManagementAPI.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InsuranceManagementAPI.CustomAttribute
{
    public class ApiKeyAuthFilter : IAuthorizationFilter
    {
        private readonly IAuthenticationService _authService;

        public ApiKeyAuthFilter(IAuthenticationService authService)
        {
            _authService = authService;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var apiKey = context.HttpContext.Request.Headers["x-api-key"];

            if (string.IsNullOrEmpty(apiKey))
            {
                context.Result = new BadRequestResult();
                return;
            }

            if (!_authService.IsValidApiKey(apiKey))
            {
                context.Result = new UnauthorizedResult();
            }

        }
    }
}
