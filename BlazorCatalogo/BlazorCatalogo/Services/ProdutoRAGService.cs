using Microsoft.Extensions.AI;

namespace BlazorCatalogo.Services
{
    public class ProdutoRAGService
    {
        private readonly VetorStore _store;
        private readonly EmbeddingService _embedding;
        private readonly IChatClient _chat;

        public ProdutoRAGService(
            VetorStore store,
            EmbeddingService embedding,
            IChatClient chat)
        {
            _store = store;
            _embedding = embedding;
            _chat = chat;
        }

        public async Task<string> PerguntarSobreProduto(string pergunta, int produtoId) // ✅ adiciona produtoId
        {
            var perguntaEmbedding = await _embedding.GerarEmbedding(pergunta);

            var docs = _store.BuscarSimilar(perguntaEmbedding, produtoId); // ✅ passa o produtoId

            var contexto = string.Join("\n\n", docs.Select(d => d.Conteudo));

            var prompt = $"""
        Use as informações abaixo para responder:

        {contexto}

        Pergunta:
        {pergunta}

        Se a resposta não estiver no contexto, diga que não encontrou informações sobre isso.
        """;

            var response = await _chat.GetResponseAsync(prompt);

            return response.Text;
        }
    }

}