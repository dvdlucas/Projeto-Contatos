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
            _contatoRepository.Remover(id);
            return RedirectToAction("Index");
        }


      
        




        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            _contatoRepository.Adicionar(contato);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {
            _contatoRepository.Editar(contato);
            return RedirectToAction("Index");
        }

    }
}
