using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyWebApp.Exceptions;

namespace MyWebApp.Filters
{
    public class SpringtrapExceptionFilter : ExceptionFilterAttribute, IExceptionFilter
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is SpringtrapException)
            {
                context.Result = new JsonResult("Filter is good!");
            } 
        }
    }
}
