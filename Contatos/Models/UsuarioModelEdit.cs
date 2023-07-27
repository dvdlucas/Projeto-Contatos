using Contatos.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contatos.Models
{
    public class UsuarioModelEdit
    {

        public int Id { get; set; }


        [Required(ErrorMessage = "Digite o nome do contato!!!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o login do contato!!!")]
        public string Login { get; set; }



        [Required(ErrorMessage = "Digite o email do contato!!!")]
        [EmailAddress(ErrorMessage = "Digite um email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Informe o Perfil do Usuario")]
        public PerfilEnum? Perfil { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}

