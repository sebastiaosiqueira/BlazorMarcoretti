using BlazorCatalogo.Data;

namespace BlazorCatalogo.Services
{
    public class VetorStore
    {
        private readonly List<DocumentoVetorial> _docs = [];

        public void Adicionar(DocumentoVetorial doc)
            => _docs.Add(doc);

        public IEnumerable<DocumentoVetorial> BuscarSimilar(float[] embedding, int produtoId) // ✅ adiciona produtoId
        {
            return _docs
                .Where(d => d.ProdutoId == produtoId) // ✅ filtra pelo produto antes de calcular similaridade
                .OrderByDescending(d => Similaridade(d.Embedding, embedding))
                .Take(3);
        }

        private float Similaridade(float[] v1, float[] v2)
        {
            float dot = 0;

            for (int i = 0; i < v1.Length; i++)
                dot += v1[i] * v2[i];

            return dot;
        }
    }
}