using Microsoft.AspNetCore.Mvc;

namespace Contatos.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
