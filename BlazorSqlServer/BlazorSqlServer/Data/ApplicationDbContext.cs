using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace BlazorSqlServer.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {

            var dbCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            if(dbCreator != null)
            {
                if (!dbCreator.CanConnect())
                {
                    dbCreator.Create();
                }
                if (!dbCreator.HasTables())
                {
                    dbCreator.CreateTables();
                }
            }
        }
        public DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
            modelbuilder.Entity<Contato>().HasData(
                new Contato() { Id = 1, Nome = "Sebastiao siqueira", Email = "sebastiaosiqueira@gmail.com" },
                new Contato() { Id = 2, Nome = "Ruth Regina", Email = "ruth@gmail" },
                new Contato() { Id = 3, Nome = "Kayon Guilherme", Email = "kayon@gmail" },
                new Contato() { Id = 4, Nome = "Emau", Email = "ruth@gmail" });
        }
    }
}
