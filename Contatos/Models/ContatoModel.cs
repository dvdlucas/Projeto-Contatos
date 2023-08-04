using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Contatos.Models
{
    public class ContatoModel
    {
        [Key]
        public int Id { get; set; }
        [Column("Nome", TypeName = "varchar(200)")]

        [Required(ErrorMessage ="Digite o nome do contato!!!")]
        public string Nome { get; set; }
        [Column("Email", TypeName = "varchar(200)")]

        [Required(ErrorMessage ="Digite o email do contato!!!")]
        [EmailAddress(ErrorMessage ="Digite um email válido")]
        public string Email { get; set; }
        [Column("Telefone", TypeName = "varchar(200)")]

        [Required(ErrorMessage ="Digite o telefone")]
        [Phone(ErrorMessage ="Digite um telefone válido")]
        public string Telefone { get; set; }

        public LoginModel LoginModel { get; set; }

    }
}
