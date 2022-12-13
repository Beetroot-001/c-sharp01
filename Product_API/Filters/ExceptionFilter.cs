using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Product_API.Exceptoins;
using System.Net;

namespace Product_API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Exception ex = context.Exception;

            Handle((dynamic)ex, context);
        }

        public void Handle(ProductNotFoundException ex, ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;

            context.Result = new JsonResult(new { message = "Product is not found" });
        }

        public void Handle(ProductIsnotValidExceptoin ex, ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = 400;

            context.Result = new JsonResult(new { message = "Product is not valid" });
        }

        public void Handle(Exception ex, ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = 500;

            context.Result = new JsonResult(new { message = ex.Message });
        }
    }
}
