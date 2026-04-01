using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorDemoProdutoCategoria.Models;

namespace BlazorDemoProdutoCategoria.Data
{
    public class BlazorDemoProdutoCategoriaContext : DbContext
    {
        public BlazorDemoProdutoCategoriaContext (DbContextOptions<BlazorDemoProdutoCategoriaContext> options)
            : base(options)
        {
        }

        public DbSet<Categoria> Categoria { get; set; } = default!;
        public DbSet<Produto> Produto { get; set; } = default!;
    }
}
