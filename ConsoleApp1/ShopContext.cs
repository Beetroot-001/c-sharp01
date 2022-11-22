using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    public class ShopContext: DbContext
    {



        public DbSet<Product> Products { get; set; }


        public ShopContext()
        {
          
            Database.EnsureCreated();

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Shop;Trusted_Connection=true;");
            
        }

       



    }
}
