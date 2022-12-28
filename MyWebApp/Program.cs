using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Data;
using MyWebApp.Filters;
using MyWebApp.Services;
using MyWebApp.Validation;
using System.Reflection;

namespace MyWebApp
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ApiContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });

            builder.Services.AddTransient<IAnimatronicRepository, AnimatronicRepository>();
            builder.Services.AddTransient<IAnimatronicService, AnimatronicService>();

            builder.Services.AddControllers((options) => {
                options.Filters.Add<SpringtrapExceptionFilter>();
            }).AddFluentValidation(options => {
                options.ImplicitlyValidateChildProperties = true;

                options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHealthChecks();

            builder.Services.AddScoped<IValidator<Animatronic>, AnimatronicValidator>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.Use(async (ctx, next) =>
            {
                await next.Invoke(ctx);
                app.Logger.LogInformation($"Request: {ctx.Request.Path}");
            });

            app.UseAuthorization();

            app.UseRouting();

            app.UseHealthChecks("/health");

            app.MapControllers();

            app.Run();
        }
    }
}