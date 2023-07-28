using Contatos.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Contatos.Controllers
{
    [PaginaParaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
