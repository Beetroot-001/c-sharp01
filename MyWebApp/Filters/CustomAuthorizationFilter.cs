using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Web.Http.Results;

namespace MyWebApp.Filters
{
    public class CustomAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private const string authDataHeaderKey = "AuthorizationData";
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                var authdata = context.HttpContext.Request.Headers[authDataHeaderKey];

                var login = authdata[0].Split(',')[0];
                var password = authdata[0].Split(',')[1];

                if (!string.Equals(login, "tysyatsky") || !string.Equals(password, "tysyatsky"))
                {
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    context.Result = new JsonResult(new { message = "Authorization failed!" });
                }
            }
            catch (Exception)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Result = new JsonResult(new { message = "Authorization failed!" });
            }
        }
    }
}
