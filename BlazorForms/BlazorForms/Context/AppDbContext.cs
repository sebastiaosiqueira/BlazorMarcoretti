using BlazorForms.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorForms.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Apple Keyboard Ipad",
                    Description = "Apple smart"
                },
                 new Product
                 {
                     Id=2,
                     Name="Apple Iphone",
                     Description= "Apple Iphone",
                 }
                );
        }
    }
}
