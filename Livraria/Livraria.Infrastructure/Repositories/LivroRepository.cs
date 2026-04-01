using Livraria.Domain.Abstractions;
using Livraria.Domain.Entities;
using Livraria.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Infrastructure.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        public LivroRepository(ApplicationDbContext context) {
            _context = context;
        }
        private readonly ApplicationDbContext _context;
        public async Task<Livro> AdicionarLivro(Livro livro)
        {
           if(_context is not null && livro is not null && _context.Livros is not null)
            {
                _context.Livros.Add(livro);
                await _context.SaveChangesAsync();
                return livro;
            }
            else
            {
                throw new InvalidOperationException("Dados inválidos...");
            }
        }

        public async  Task AtualizarLivro(Livro livro)
        {
            if(livro is not null)
            {
                _context.Entry(livro).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeletarLivro(int id)
        {
           var livro = await ObterLivro(id);
            if(livro is not null)
            {
                _context.Livros.Remove(livro);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Dados inválidos ...");
            }
        }

        public async  Task<Livro?> ObterLivro(int id)
        {
            var livro = await _context.Livros.FirstOrDefaultAsync(l=> l.LivroId == id);

            if (livro is null)
                throw new InvalidOperationException($"Livro com ID {id} não encontrado!");
            return livro;
        }

        public async Task<IEnumerable<Livro>> ObterLivros()
        {
            if(_context is not null && _context.Livros is not null)
            {
                var livros = await _context.Livros.ToListAsync();
                return livros;
            }
            else
            {
                return new List<Livro>();
            }
        }
    }
}
