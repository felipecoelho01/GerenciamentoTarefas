using GerenciamentoTarefas.Models;
using GerenciamentoTarefas.Models.Entities;
using GerenciamentoTarefas.Services;
using GerenciamentoTarefas.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoTarefas.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public LoginController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View("Login");
        }

        [HttpPost]
        [Route("login/FazerLogin")]
        public async Task<IActionResult> Login([FromForm] DoLoginViewModel vm)
        {
            var loginList = await dbContext.TbLogin
                .Where(login => login.Email == vm.Email && login.Senha == vm.Senha)
                .ToListAsync();

            if (loginList.Count == 0)
            {
                return Json(new { success = false, message = "Email não cadastrado!" });
            }

            return Json(new { success = true, message = "Login Realizado!" });
        }
    }
}
