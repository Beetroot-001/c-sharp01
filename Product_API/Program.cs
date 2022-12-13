using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Product_API.Context;
using Product_API.Controller;
using Product_API.Data;
using Product_API.Filters;
using Product_API.MyHealthChecks;
using Product_API.Services;
using Product_API.Servises;
using Product_API.Validation;
using Microsoft.AspNetCore.JsonPatch;

namespace Product_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container. Реєстрація залежностей
            builder.Services.AddDbContext<ProductsContext>(options =>
            {
                var conectionString = builder.Configuration.GetConnectionString("Default");

                options.UseSqlServer(conectionString);


            });

            builder.Services.AddTransient<ProductValidation>();

            builder.Services.AddTransient<MyCustomAuthorization>();
            builder.Services.AddHealthChecks().AddCheck<CheckSQLServer>("Sql server");

            builder.Services.Configure<AdminAuthData>(builder.Configuration.GetSection("AdminAuthData")); 
            builder.Services.AddTransient<IProductsRepo, ProductRepo>();
            builder.Services.AddTransient<IProductServices, ProductServices>();
            builder.Services.AddControllers(options =>
            {
                options.Filters.Add(typeof(ExceptionFilter));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline. Що за чим буде виконуватися. Як оброблятиметься запит

            app.MapHealthChecks("/health");

            app.UseRouting();

            app.MapControllers(); 

            app.Run();
        }
    }
}