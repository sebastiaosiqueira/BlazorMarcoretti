using Microsoft.EntityFrameworkCore;

namespace Catalogo_Blazor.Utils
{
    public static class HttpContextExtensions
    {
        public async static Task InserirParametrosEmPageResponse<T>(this HttpContext context, IQueryable<T> queryable, int quantidadeTotalRegistrosAExibir)
        {
            if(context==null) throw new ArgumentNullException("context");
            double quantidadeRegistroTotal = await queryable.CountAsync();

            //salvando as informaçoes no header do response
            double totalPaginas = Math.Ceiling(quantidadeRegistroTotal / quantidadeTotalRegistrosAExibir);
            context.Response.Headers.Add("quantidadeRegistrosTotal", quantidadeRegistroTotal.ToString());
            context.Response.Headers.Add("totalPaginas", totalPaginas.ToString());
        }
    }
}
