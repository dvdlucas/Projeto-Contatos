using Contatos.Enums;
using Contatos.Helper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contatos.Models
{
    public class UsuarioModel
    {
        
        public int Id { get; set; }

    
        [Required(ErrorMessage = "Digite o nome do contato!!!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o login do contato!!!")]
        public string Login { get; set; }


    
        [Required(ErrorMessage = "Digite o email do contato!!!")]
        [EmailAddress(ErrorMessage = "Digite um email válido")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Informe o Perfil do Usuario")]
        public PerfilEnum? Perfil { get; set; }

        [Required(ErrorMessage ="Digite a senha do usuário")]
        public string Senha { get; set; }
        
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void setSenhaHash()
        {
            Senha = Senha.GerarHash();
        }

        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novaSenha.GerarHash();
            return novaSenha;
        }


    }
}
