using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyWebApi.Exceptions;

namespace MyWebApi.Filters
{
	public class ExceptionFilter : IExceptionFilter
	{
		public void OnException(ExceptionContext context)
		{
			Exception ex = context.Exception;

			Handle((dynamic)ex, context);
		}

		public void Handle(PersonNotFoundException ex, ExceptionContext context)
		{
			context.HttpContext.Response.StatusCode = 404;

			context.Result = new JsonResult(new { message = "Person is not found" });
		}

		public void Handle(PersonIsInvalidException ex, ExceptionContext context)
		{
			context.HttpContext.Response.StatusCode = 400;

			context.Result = new JsonResult(new { message = "Person is not valid" });
		}

		public void Handle(Exception ex, ExceptionContext context)
		{
			context.HttpContext.Response.StatusCode = 500;

			context.Result = new JsonResult(new { message = "UNHANDLED EXCEPTION" });
		}
	}
}
