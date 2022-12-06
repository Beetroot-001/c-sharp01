using Microsoft.AspNetCore.Mvc;
using MyWebApp.Exceptions;
using System.Web.Http.Filters;

namespace MyWebApp.Filters
{
    public class SpringtrapExceptionFilter : ExceptionFilterAttribute, IExceptionFilter
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is SpringtrapException)
            {
                context.Response = new HttpResponseMessage(System.Net.HttpStatusCode.NotAcceptable);
            } 
        }
    }
}
