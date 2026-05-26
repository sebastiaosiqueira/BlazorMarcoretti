namespace BlazorCatalogo.Data
{
    public class DocumentoVetorial
    {
        public string Conteudo { get; set; } = "";

        public float[] Embedding { get; set; } = [];

        public int ProdutoId { get; set; }
    }
}
