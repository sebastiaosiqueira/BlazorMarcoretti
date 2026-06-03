using System.ComponentModel.DataAnnotations;

namespace BlazorMangas.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "O campo email é obrigatório")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório")]
        public string? Password { get; set; }
    }
}
