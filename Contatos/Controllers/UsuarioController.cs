using Contatos.Models;
using Contatos.Repository;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Contatos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = (UsuarioRepository?)usuarioRepository;
        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuarioModels = _usuarioRepository.BuscarTodos();
            return View(usuarioModels);
        }
        
        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepository.ListarPorId(id);
            return View(usuario);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Excluir(int id)
        {
            UsuarioModel usuario = _usuarioRepository.ListarPorId(id);
            return View(usuario);
        }


        
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _usuarioRepository.Remover(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuário Excluído com Sucesso";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MensagemErro"] = $"Ops, não conseguimos realizar sua solicitação, Tente novamente";

                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar sua solicitação, Tente novamente{erro.Message}";
                return RedirectToAction("Index");
            }
        }





        


        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepository.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário cadastro com sucesso";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops. algo não saiu como planejado, não conseguimos cadastrar seu contato, Tente novamente : {erro.Message}";
                return RedirectToAction("Index");
            }

        }
        


        [HttpPost]
        public IActionResult Editar(UsuarioModelEdit usuarioED)
        {
            try
            {
                UsuarioModel usuario = null;

                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioED.Id,
                        Nome = usuarioED.Nome,
                        Login = usuarioED.Login,
                        Email = usuarioED.Email,
                        Perfil = usuarioED.Perfil
                    };

                   usuario = _usuarioRepository.Editar(usuario);
                    TempData["MensagemSucesso"] = "Usuario atualizado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", usuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, algo não saiu como o planejado, não conseguimos atualizar o usuario, Tente novamente {erro.Message}";
                return RedirectToAction("Index");
            }
        
        }
        
    }
}
