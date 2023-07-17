using Microsoft.AspNetCore.Mvc;

namespace Contatos.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
