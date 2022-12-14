using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
			});

			builder.Services.AddIdentity<IdentityUser<int>, IdentityRole<int>>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				//.AddRoleManager<IdentityRole<int>>()
				//.AddUserManager<IdentityUser<int>>()
				.AddDefaultTokenProviders();

			// Add services to the container.

			builder.Services.AddControllers();

			builder.Services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer();

			builder.Services.AddAuthorization();


			var app = builder.Build();

			// Configure the HTTP request pipeline.

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}