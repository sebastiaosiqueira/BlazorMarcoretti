using Microsoft.Extensions.AI;

namespace BlazorCatalogo.Services
{
    public class EmbeddingService
    {
        private readonly IEmbeddingGenerator<string, Embedding<float>> _generator;

        public EmbeddingService(IEmbeddingGenerator<string, Embedding<float>> generator)
        {
            _generator = generator;
        }

        public async Task<float[]> GerarEmbedding(string texto)
        {
            var embedding = await _generator.GenerateAsync(texto);

            return embedding.Vector.ToArray();
        }
    }
}