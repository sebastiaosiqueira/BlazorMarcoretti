using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo_Blazor.Shared.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        [Required(ErrorMessage ="O nome da categoria é obrigatório")]
        [MaxLength(100)]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "O nome da descrição é obrigatório")]
        [MaxLength(200)]
        public string? Descricao { get; set; }

        public ICollection<Produto>? Produtos { get; set; }
    }
}
