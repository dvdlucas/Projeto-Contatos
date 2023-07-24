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

        [Required(ErrorMessage ="Digite o email do contato !!!")]
        [EmailAddress(ErrorMessage ="o email informado não é válido !!!")]
        public string Email { get; set; }
        [Column("Telefone", TypeName = "varchar(200)")]

        [Required (ErrorMessage ="Digite o telefone do contato !!!")]
        [Phone(ErrorMessage ="O Telefone informado não é válido !!!")]
        public string Telefone { get; set; }

    }
}
