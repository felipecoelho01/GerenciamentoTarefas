using GerenciamentoTarefas.Models;
using GerenciamentoTarefas.Models.Entities;
using GerenciamentoTarefas.Services;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Login(DoLoginViewModel viewModel)
        {
            var login = new Lista
            {
                Email = viewModel.Email,
                Senha = viewModel.Senha,
            };

            await dbContext.TbLogin.AddAsync(login);
            await dbContext.SaveChangesAsync();

            return View();
        }
    }
}
