using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace MyWebApi.Filters
{
	public class MyCustomAuthorization : Attribute, IAuthorizationFilter
	{
		private const string authDataHeaderKey = "AuthData";
		public void OnAuthorization(AuthorizationFilterContext context)
		{
			try
			{
				var authData = context.HttpContext.Request.Headers[authDataHeaderKey];

				var userName = authData[0].Split(',')[0];
				var password = authData[0].Split(',')[1];


				const string adminLogin = "admin";
				const string adminPassword = "admin";

				if (!string.Equals(adminLogin, userName) || !string.Equals(adminPassword, password))
				{
					context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

					context.Result = new JsonResult(new { message = "Auth data is missing or invalid" });
				}

			}
			catch (Exception ex)
			{
				context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
				context.Result = new JsonResult(new { message = "Auth data is missing or invalid" });
			}
		}
	}
}
