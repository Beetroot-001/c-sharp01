using Microsoft.EntityFrameworkCore;
using MyWebApi.Data;
using MyWebApi.Services;

namespace MyWebApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
			{
				var connectionString = builder.Configuration.GetConnectionString("Default");
				options.UseSqlServer(connectionString);
			});

			builder.Services.AddTransient<IPeopleRepo, PeopleRepo>();
			builder.Services.AddTransient<IPeopleService, PeopleService>();

			builder.Services.AddControllers().AddNewtonsoftJson();

			var app = builder.Build();

			// Configure the HTTP request pipeline.

			app.UseRouting();

			app.MapControllers();

			app.Run();
		}
	}
}