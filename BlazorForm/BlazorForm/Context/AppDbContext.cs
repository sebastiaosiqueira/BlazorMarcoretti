using BlazorForm.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorForm.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options): base(options) { }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Apple Keyboard Ipad",
                    Description = "Apple Smart Keyboard for Ipad"
                },
                new Product
                {
                    Id = 2,
                    Name = "Apple Iphone 15",
                    Description = "Apple Iphone 15 63gb gsm"
                }
                );
               
            }
        }

    }
