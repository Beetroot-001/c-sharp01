using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System.Net;

namespace MyWebApi.Filters
{
	public class MyCustomAuthorization : Attribute, IAuthorizationFilter
	{
		private const string authDataHeaderKey = "AuthData";

		private readonly AdminAuthData options;
		public MyCustomAuthorization(IOptions<AdminAuthData> options)
		{
			this.options = options.Value;
		}

		public void OnAuthorization(AuthorizationFilterContext context)
		{
			try
			{
				var authData = context.HttpContext.Request.Headers[authDataHeaderKey];

				var userName = authData[0].Split(',')[0];
				var password = authData[0].Split(',')[1];


				if (!string.Equals(options.UserName, userName) || !string.Equals(options.Password, password))
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
