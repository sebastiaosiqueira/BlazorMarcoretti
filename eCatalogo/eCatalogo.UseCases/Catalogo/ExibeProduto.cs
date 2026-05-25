using eCatalogo.Core.Models;
using eCatalogo.UseCases.Interfaces.Repository;

namespace eCatalogo.UseCases.Catalogo
{
    public class ExibeProduto : IExibeProduto
    {
        private readonly IProdutoRepository produtoRepository;

        public ExibeProduto(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public Produto Execute(int id)
        {
            return produtoRepository.GetProduto(id);
        }
    }
}
