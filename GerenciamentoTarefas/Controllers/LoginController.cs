using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoTarefas.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}
