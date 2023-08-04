using System.ComponentModel.DataAnnotations;

namespace Contatos.Models
{
   
        public class AlterarSenhaModel
        {
            public int Id { get; set; }


            [Required(ErrorMessage = "Digite a Senha Atual !!!")]
             public string SenhaAtual { get; set; }

            [Required(ErrorMessage = "Digite a nova Senha !!!")]
            public string NovaSenha { get; set; }

           [Required(ErrorMessage = "Confirme a nova Senha !!!")]
           [Compare("NovaSenha", ErrorMessage ="As senhas devem ser iguais")]
            public string ConfirmarSenha { get; set; }



    }
    }


