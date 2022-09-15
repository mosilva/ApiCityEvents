using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiCityEvents.Filters
{
    public class LogAuthorizationGenerateCode : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            if (!context.HttpContext.Request.Headers.Keys.Contains("Code"))
            {
                context.HttpContext.Request.Headers.Add("Code",Guid.NewGuid().ToString());
            }


        }
    }
}
