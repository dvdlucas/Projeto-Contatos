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
        private readonly IEmail _email;

        public LoginController(IUsuarioRepository usuarioRepository, ISessao sessao, IEmail email)
        {
            _usuarioRepository = usuarioRepository;
            _sessao = sessao;
            _email = email;
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


        public IActionResult RedefinirSenha()
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

        [HttpPost]
        public IActionResult EnviarLink(RedefinirSenhaModel redefinirSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepository.BuscarPorEmailLogin(redefinirSenhaModel.Email, redefinirSenhaModel.Login);

                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();
                        string mensagem = $"Sua nova senha é : {novaSenha}";

                      bool emailEnviado = _email.Enviar(usuario.Email, "Sistema de Contatos - Nova Senha",mensagem);
                        if (emailEnviado)
                        {
                            _usuarioRepository.Editar(usuario);
                            TempData["MensagemSucesso"] = $"Enviamos para o seu email cadastrado uma nova senha !";
                        }
                        else
                        {
                            TempData["MensagemErro"] = $"Não conseguimos envial o email. Por Favor,verifique os dados informados e tente novamente!!!";
                        }
                        return RedirectToAction("Index","Login");
                    }
                    TempData["MensagemErro"] = $"Não conseguimos atualizar sua senha. Por Favor,verifique os dados informados e tente novamente !!!";



                }
                return View("RedefinirSenha");

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops,Não conseguimos atualizar sua Senha, Tente novamente !!! ,{erro.Message}";
                return RedirectToAction("RedefinirSenha");
            }
        }







    }
}
