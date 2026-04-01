using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorDemoProdutoCategoria.Models
{
    public class Produto
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Nome { get; set; }=string.Empty;
        [MaxLength(200)]
        public string Descricao { get; set; } = string.Empty;
        [MaxLength(200)]
        public string ImagemUrl { get; set; }=string.Empty;
        [Column(TypeName ="decimal(10,2)")]
        public decimal Preco { get; set; } = 0;
        [ForeignKey("CategoriaId_PK")]
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
    }
}
