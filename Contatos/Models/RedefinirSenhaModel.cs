using System.ComponentModel.DataAnnotations;

namespace Contatos.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Digite o Login !!!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite o email !!!")]
        public string Email { get; set; }



    }
}