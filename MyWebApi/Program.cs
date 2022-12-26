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
            //builder.Services.AddAuthorization();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });
            builder.Services.AddTransient<IUserRepo, UserRepo>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddControllers().AddNewtonsoftJson();


            var app = builder.Build();
            app.UseRouting();
            app.MapControllers();

            // Configure the HTTP request pipeline.
            //app.UseAuthorization();

            app.Run();
        }
    }
}