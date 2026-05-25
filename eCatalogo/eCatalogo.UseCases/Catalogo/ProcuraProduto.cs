using eCatalogo.Core.Models;
using eCatalogo.UseCases.Interfaces.Repository;


namespace eCatalogo.UseCases.Catalogo
{
    public class ProcuraProduto : IProcuraProduto
    {
        private readonly IProdutoRepository produtoRepository;

        public ProcuraProduto(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public IEnumerable<Produto> Execute(string filter = null)
        {
            return produtoRepository.GetProdutos(filter);
        }
    }
}