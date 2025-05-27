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
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login/RelizarLogin")]
        public async Task<IActionResult> Login(DoLoginViewModel vm)
        {
            var login = await dbContext.TbLogin.Where(login => login.Email == vm.Email && login.Senha == vm.Senha).ToListAsync();

            var verifyModel = new VerifyModel
            {
                verifica = login.Count() != 0,
                mensagem = login.Count() != 0 ? "Login Realizado!" : "Email ou Senha incorreta!",
            };

            return View();
        }
    }
}
