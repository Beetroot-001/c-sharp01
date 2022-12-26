using Microsoft.AspNetCore.Mvc.Filters;

namespace MyWebApi.Filters
{
    public class MyCustomAuth : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            
        }
    }
}
