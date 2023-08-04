
using Contatos.Helper;
using Contatos.Models;
using Contatos.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Contatos.Controllers
{
    public class AlterarSenhaController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        private readonly ISessao _sessao;
        public AlterarSenhaController(IUsuarioRepository usuarioRepository, ISessao sessao)
        {
            _usuarioRepository = usuarioRepository;
            _sessao = sessao;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(AlterarSenhaModel alterarSenhaModel)
        {
            try
            {
                UsuarioModel usuarioLogado = _sessao.BuscarSessao();
                alterarSenhaModel.Id = usuarioLogado.Id;
                if (ModelState.IsValid)
                {
                    _usuarioRepository.AlterarSenha(alterarSenhaModel);

                    TempData["MensagemSucesso"] = "Senha alterada com Sucesso";
                }
                
                return View("Index", alterarSenhaModel);

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos alterar sua senha, Tente novamente {erro.Message}";
                return View("Index", alterarSenhaModel);
      
            
            }

        }
    }
}
         

    

