using BlazorShop.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Api.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Produto>? Produtos { get; set; }
        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Carrinho>? Carrinhos { get; set; }
        public DbSet<CarrinhoItem>? CarrinhoItens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Categoria>()
                .HasData(
                    new Categoria { Id = 1, Nome = "Beleza", IconCSS = "ProductionQuantityLimits" },
                    new Categoria { Id = 2, Nome = "Roupas", IconCSS = "Checkroom" },
                    new Categoria { Id = 3, Nome = "Livros", IconCSS = "LibraryBooks" }
                );
            modelBuilder.Entity<Produto>()
                .HasData(
                    new Produto { Id = 1, Nome = "Shampoo", Descricao = "Shampoo para cabelos oleosos", Preco = 19.99m, CategoriaId = 1, ImagemUrl = "/Imagens/Beleza/Beleza.1.png" },
                    new Produto { Id = 2, Nome = "Camiseta", Descricao = "Shampoo para cabelos oleosos", Preco = 19.99m, CategoriaId = 2, ImagemUrl = "/Imagens/Beleza/Beleza.1.png" },
                    new Produto { Id = 3, Nome = "Saia", Descricao = "Shampoo para cabelos oleosos", Preco = 19.99m, CategoriaId = 2, ImagemUrl = "/Imagens/Beleza/Beleza.1.png" },
                    new Produto { Id = 4, Nome = "Shareook", Descricao = "Shampoo para cabelos oleosos", Preco = 19.99m, CategoriaId = 3, ImagemUrl = "/Imagens/Beleza/Beleza.1.png" },
                    new Produto { Id = 5, Nome = "O vento levou", Descricao = "Shampoo para cabelos oleosos", Preco = 19.99m, CategoriaId = 3, ImagemUrl = "/Imagens/Beleza/Beleza.1.png" },
                    new Produto { Id = 6, Nome = "Samurai", Descricao = "Shampoo para cabelos oleosos", Preco = 19.99m, CategoriaId = 3, ImagemUrl = "/Imagens/Beleza/Beleza.1.png" }



                );
            modelBuilder.Entity<Usuario>()
                .HasData(
                    new Usuario { Id = 1, NomeUsuario = "Sebastiao"

                    });
        }
    }
}
