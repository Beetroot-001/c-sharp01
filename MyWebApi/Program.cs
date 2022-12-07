using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyWebApi.Data;
using MyWebApi.Filters;
using MyWebApi.HealthChecks;
using MyWebApi.Services;
using Serilog;

namespace MyWebApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Host.UseSerilog((ctx, lc) => lc
					.WriteTo.Console()
					.ReadFrom.Configuration(ctx.Configuration));

			if (builder.Environment.IsDevelopment())
			{
				builder.Configuration.AddJsonFile("appsettings.local.json", optional: false, reloadOnChange: true);
			}

			builder.Services.AddSingleton<ApplicationDbContext>(x =>
			{
				var context = x.GetRequiredService<ApplicationDbContext>();
				context.Database.Migrate();

				var connectionString = builder.Configuration.GetConnectionString("Default");
				var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
				optionsBuilder.UseSqlServer(connectionString);

				return new ApplicationDbContext(optionsBuilder.Options);
			});

			builder.Services.Configure<AdminAuthData>(builder.Configuration.GetSection("AdminAuthData"));

			builder.Services.AddSingleton<IPeopleRepo>(services =>
			{
				var applicationDbContext = services.GetService<ApplicationDbContext>();
				return new PeopleRepo(applicationDbContext);
			});

			builder.Services.AddTransient<IPeopleService, PeopleService>();

			builder.Services.AddControllers(options =>
			{
				options.Filters.Add(typeof(ExceptionFilter));

			}).AddNewtonsoftJson();

			builder.Services.AddSwaggerGen();

			builder.Services.AddHealthChecks().AddCheck<SqlServerHealthCheck>("sql server");

			var app = builder.Build();

			// Configure the HTTP request pipeline.

			app.UseSerilogRequestLogging();

			app.UseRouting();

			app.UseSwagger();
			app.UseSwaggerUI();

			app.Use((context, next) =>
			{
				context.Response.Headers["OLALA"] = "THIS IS MY HEADER";

				return next();
			});

			app.UseHealthChecks("/health");

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			app.Run();
		}
	}
}