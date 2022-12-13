using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Product_API.Filters
{
    public class MyActionFiltr : IActionFilter
    {
        private readonly ILogger _logger;

        public MyActionFiltr(ILogger<MyActionFiltr> logger)
        {
            this._logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
           _logger.LogInformation("End request");
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("Start request");
        }
    }
}
