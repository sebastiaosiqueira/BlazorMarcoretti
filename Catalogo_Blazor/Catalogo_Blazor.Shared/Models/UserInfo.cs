using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo_Blazor.Shared.Models
{
    public class UserInfo
    {
        [Required(ErrorMessage ="Informe o email")]
        [EmailAddress(ErrorMessage = "O formato do email inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Informe a password")]
        public string Password { get; set; }
    }
}
