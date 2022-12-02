using Microsoft.AspNetCore.Mvc.Filters;

namespace MyWebApi.Filters
{
	public class MyActionFilter : Attribute, IActionFilter
	{
		public void OnActionExecuted(ActionExecutedContext context)
		{
			Console.WriteLine($"[MY LOG] Action executing {context.ActionDescriptor.DisplayName}");
		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			Console.WriteLine($"[MY LOG] Action executed {context.ActionDescriptor.DisplayName}");

		}
	}
}
