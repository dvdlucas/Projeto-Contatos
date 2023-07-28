using Contatos.Filters;
using Contatos.Models;
using Contatos.Repository;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Contatos.Controllers
{
    [PaginaParaUsuarioLogado]

    public class ContatoController : Controller
    {
        private readonly ContatoRepository _contatoRepository;
        public ContatoController(IContatoRepository contatoRepository)
        {
            _contatoRepository = (ContatoRepository?)contatoRepository;
        }
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepository.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepository.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Excluir(int id)
        {
            ContatoModel contato = _contatoRepository.ListarPorId(id);
            return View(contato);
        }



        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatoRepository.Remover(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato Excluído com Sucesso";
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
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepository.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastro com sucesso";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops. algo não saiu como planejado, não conseguimos cadastrar seu contato, Tente novamente : {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepository.Editar(contato);
                    TempData["MensagemSucesso"] = "Contato atualizado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", contato);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, algo não saiu como o planejado, não conseguimos atualizar o contato, Tente novamente {erro.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}
