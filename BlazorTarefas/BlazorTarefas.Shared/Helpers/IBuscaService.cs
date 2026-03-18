using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTarefas.Shared.Helpers
{
    public interface IBuscaService
    {
        ListaPaginada<T> FiltrarEPaginar<T>(
            IEnumerable<T> fonte,
            string termo,
            int paginaAtual,
            int tamanhoPagina,
            Func<T, string, bool> filtroLogica,
            string campoOrdenacao = null, 
            bool ascendente=true);
    }
}
