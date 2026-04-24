using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudBlazorDemo.Data
{
    public class Bolo
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string? Nome { get; set; }
        [MaxLength(300)]
        public string? Descricao { get; set; }
        public string? ImagemUrl { get; set; }
        [Column(TypeName="decimal(10,2)")]
        public decimal Preco { get; set; }
    }
}
