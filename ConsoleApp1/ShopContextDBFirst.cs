using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ShopContextDBFirst : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public ShopContextDBFirst()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Shop;Trusted_Connection=True;");
        }
    }
}
