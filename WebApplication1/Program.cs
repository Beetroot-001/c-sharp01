using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;
using WebApplication1.Controllers;
using WebApplication1.Validators;

namespace WebApplication1
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddAuthorization();

			builder.Services.AddCors(options =>
			{
				options.AddDefaultPolicy(defaultPolicy =>
				{
					defaultPolicy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
				});
			});

			builder.Services.AddControllers().AddFluentValidation(options =>
			{
				// Validate child properties and root collection elements
				options.ImplicitlyValidateChildProperties = true;
				options.DisableDataAnnotationsValidation = true;

				// Automatic registration of validators in assembly
				options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
			});


			var app = builder.Build();

			// Configure the HTTP request pipeline.

			app.UseCors();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}