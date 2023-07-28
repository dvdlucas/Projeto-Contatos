using Contatos.Helper;
using Contatos.Models;
using Contatos.Repository;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Contatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISessao _sessao;

        public LoginController(IUsuarioRepository usuarioRepository, ISessao sessao)
        {
            _usuarioRepository = usuarioRepository;
            _sessao = sessao;
        }



        public IActionResult Index()
        {
            //se usuario estiver logado, redirecionar par o home

            if(_sessao.BuscarSessao() != null) return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessao(_sessao.BuscarSessao());

            return RedirectToAction("Index", "Login");
        }





        [HttpPost]

        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepository.BuscarPorLogin(loginModel.Login);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessao(usuario);
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = $"Senha do usuário inválida(s). Por Favor, tente novamente !!!";

                    }
                    TempData["MensagemErro"] = $"Usuário e senha inválido. Por Favor, tente novamente !!!";



                }
                return View("Index");

            }catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, Impossivel Realizar Login , Tente novamente ,{erro.Message}";
                return RedirectToAction("Index");
            }
        }





    }
}
