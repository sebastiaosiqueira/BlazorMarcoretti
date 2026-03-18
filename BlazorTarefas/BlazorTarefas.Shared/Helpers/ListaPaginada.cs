using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTarefas.Shared.Helpers
{
    public class ListaPaginada<T> : List<T>
    {
        public int PaginaAtual { get; private set; }
        public int TotalPaginas { get; private set; }
        public int TamanhoPagina { get; private set; }
        public int TotalItens { get; private set; }

        public bool TemPaginaAnterior => PaginaAtual > 1;
        public bool TemProximaPagina => PaginaAtual < TotalPaginas;

        public ListaPaginada(List<T> itens, int contagem, int indicePagina, int tamanhoPagina)
        {
            PaginaAtual = indicePagina;
            TotalPaginas = (int)Math.Ceiling(contagem / (double)tamanhoPagina);
            if (TotalPaginas == 0) TotalPaginas = 1;
            TamanhoPagina = tamanhoPagina;
            TotalItens = contagem;

            this.AddRange(itens);
        }

        // Método estático para facilitar a criação
        public static ListaPaginada<T> Criar(IEnumerable<T> fonte, int indicePagina, int tamanhoPagina)
        {
            var contagem = fonte.Count();

            // Se estou na página 2 e o tamanho é 5, (2-1)*5 = Pula os primeiros 5 itens.
            var itens = fonte.Skip((indicePagina - 1) * tamanhoPagina)
                             .Take(tamanhoPagina)
                             .ToList();

            return new ListaPaginada<T>(itens, contagem, indicePagina, tamanhoPagina);
        }
    }
}