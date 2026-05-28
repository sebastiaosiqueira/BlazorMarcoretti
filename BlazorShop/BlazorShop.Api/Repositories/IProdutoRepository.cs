using BlazorShop.Api.Entities;

namespace BlazorShop.Api.Repositories
{
    public interface IProdutoRepository
    {
            Task<IEnumerable<Produto>> GetItens();
            Task<Produto> GetIem(int id);
            Task<IEnumerable<Produto>> GetItensPorCategoria(int id);
       
    }
}
