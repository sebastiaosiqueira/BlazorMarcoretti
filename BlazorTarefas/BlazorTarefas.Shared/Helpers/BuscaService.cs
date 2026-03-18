using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTarefas.Shared.Helpers
{
    public class BuscaService : IBuscaService
    {
        public ListaPaginada<T> FiltrarEPaginar<T>(
            IEnumerable<T> fonte,
            string termo,
            int paginaAtual,
            int tamanhoPagina,
            Func<T, string, bool> filtroLogica,
            string campoOrdenacao = null,
            bool ascendente = true)
        {
            // 1. Filtragem
            var resultado = string.IsNullOrWhiteSpace(termo)
                ? fonte
                : fonte.Where(item => filtroLogica(item, termo));

            // 2. Ordenação Dinâmica
            if (!string.IsNullOrWhiteSpace(campoOrdenacao))
            {
                var prop = typeof(T).GetProperty(campoOrdenacao,
                    System.Reflection.BindingFlags.IgnoreCase |
                    System.Reflection.BindingFlags.Public |
                    System.Reflection.BindingFlags.Instance);

                if (prop != null)
                {
                    resultado = ascendente
                        ? resultado.OrderBy(x => prop.GetValue(x, null))
                        : resultado.OrderByDescending(x => prop.GetValue(x, null));
                }
            }

            // 3. Paginação
            return ListaPaginada<T>.Criar(resultado, paginaAtual, tamanhoPagina);
        }
    }
}