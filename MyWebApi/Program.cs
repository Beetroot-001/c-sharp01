using Microsoft.EntityFrameworkCore;
using MyWebApi.Data;
using MyWebApi.Filters;
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

			builder.Services.AddControllers(options =>
			{
				options.Filters.Add(typeof(ExceptionFilter));

			}).AddNewtonsoftJson();

			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.

			app.UseRouting();

			app.UseSwagger();
			app.UseSwaggerUI();


			app.Use((context, next) =>
			{
				context.Response.Headers["OLALA"] = "THIS IS MY HEADER";

				return next();
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			

			app.Run();

			
		}
	}
}