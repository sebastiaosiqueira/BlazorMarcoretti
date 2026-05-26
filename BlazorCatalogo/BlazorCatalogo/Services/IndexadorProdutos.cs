using BlazorCatalogo.Data;
using Microsoft.Extensions.AI;

namespace BlazorCatalogo.Services
{
    public class IndexadorProdutos
    {
        public async Task Indexar(
        ProdutoRepository repo,
        EmbeddingService embedding,
        VetorStore store)
        {
            foreach (var p in repo.ObterTodos())
            {
                var vetor = await embedding.GerarEmbedding(p.DocumentoInformacoes);

                store.Adicionar(new DocumentoVetorial
                {
                    ProdutoId = p.Id,
                    Conteudo = p.DocumentoInformacoes,
                    Embedding = vetor
                });
            }
        }
    }
}
