using Microsoft.AspNetCore.Mvc;

namespace InsuranceManagementAPI.CustomAttribute
{
    public class ApiKeyAttribute : ServiceFilterAttribute
    {
        public ApiKeyAttribute()
            :base(typeof(ApiKeyAuthFilter))
        {  
        }
    }
}
