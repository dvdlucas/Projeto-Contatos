using Contatos.Models;
using Contatos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Contatos.Controllers
{
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

        public IActionResult Editar() 
        { 
            return View();
        }

        public IActionResult Criar() 
        {
            return View();
        }

        public IActionResult Excluir() 
        { 
            return View();
        }
        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            _contatoRepository.Adicionar(contato);
            return RedirectToAction("Index");
        }



    }
}
