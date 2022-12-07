using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;

namespace MyWebApi.Filters
{
	public class MyActionFilter : Attribute, IActionFilter
	{
		private readonly ILogger<MyActionFilter> logger;

		public MyActionFilter(ILogger<MyActionFilter> logger)
		{
			this.logger = logger;
		}

		public void OnActionExecuted(ActionExecutedContext context)
		{
			logger.LogInformation($"[MY LOG] Action executing {context.ActionDescriptor.DisplayName}");
		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			logger.LogInformation($"[MY LOG] Action executed {context.ActionDescriptor.DisplayName}");
		}
	}
}
