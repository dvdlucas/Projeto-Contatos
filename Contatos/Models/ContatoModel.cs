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
        public string Nome { get; set; }
        [Column("Email", TypeName = "varchar(200)")]
        public string Email { get; set; }
        [Column("Telefone", TypeName = "varchar(200)")]
        public string Telefone { get; set; }

    }
}
