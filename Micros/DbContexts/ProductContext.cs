using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Micro.Models;
using Microsoft.EntityFrameworkCore;

namespace Micro.DbContexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options):base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Electronics",
                    Description = "Electronics Items"
                },
                 new Category
                 {
                     Id = 2,
                     Name = "Cloths",
                     Description = "Dresses"
                 },

                   new Category
                   {
                       Id = 3,
                       Name = "Grocery",
                       Description = "Grocery Items"
                   }

                );
        }

    }
}
