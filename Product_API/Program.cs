using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Product_API.Context;
using Product_API.Controller;
using Product_API.Data;
using Product_API.Services;
using Product_API.Servises;

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
                //options.UseInMemoryDatabase("MyDb");
            });// Лямбда що конфігурує контекст.
            //Якщо ми вказували то в контексті навіщо ще раз? чи метод OnConfiguring в контексті топосуті те саме?

            builder.Services.AddTransient<IProductsRepo, ProductRepo>();// тут я вказую інтерфейс і конкретний клас який його реалізує? і тоді цей клас підбереться в контроллері?? це треба для того щоб у всіх контролеррах був один і той самий екземпляр? а якщо додати декілька таких записів з різною реалізацією який вибире?
            builder.Services.AddTransient<IProductServices, ProductServices>();// і ми створювали інтерфейси для цього додавання?

            builder.Services.AddControllers();// додаємо контроллери

           var app = builder.Build();

            // Configure the HTTP request pipeline. Що за чим буде виконуватися. Як оброблятиметься запит

            app.UseRouting();//щоб таблиця роутів збудувалася. Що таке роут, таблиця роутів?

            app.MapControllers(); // Щоб змапилися контроллери, що це значить і навіщо?

            app.Run();
        }
    }
}