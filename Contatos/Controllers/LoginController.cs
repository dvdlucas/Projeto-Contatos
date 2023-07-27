using Contatos.Models;
using Contatos.Repository;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Contatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }



        public IActionResult Index()
        {
            return View();
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
