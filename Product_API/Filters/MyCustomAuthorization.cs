using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Product_API.Filters
{
    public class MyCustomAuthorization : Attribute, IAuthorizationFilter 
    {
        private readonly AdminAuthData _options;

        public MyCustomAuthorization(AdminAuthData options)
        {
            this._options = options;
        }

        private const string _authDataKey = "AuthData";
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                var authData = context.HttpContext.Request.Headers[_authDataKey];

                var userName = authData[0].Split(',')[0];
                var userPassword = authData[0].Split(',')[1];



                if (!string.Equals(_options.login, userName) || !string.Equals(_options.password, userPassword))
                {
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    context.Result = new JsonResult(new { message = "Not Valid" });
                }
            }
            catch (Exception ex)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Result = new JsonResult(new { message = ex.Message });
            }
        }
    }
}
