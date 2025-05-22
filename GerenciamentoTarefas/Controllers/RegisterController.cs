using GerenciamentoTarefas.Models.Entities;
using GerenciamentoTarefas.Services;
using GerenciamentoTarefas.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoTarefas.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public RegisterController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(DoRegisterViewModel vm)
        {
            if (vm.Senha != vm.SenhaConfirm)
            {
                return View();
            }

            var register = new Lista
            {
                Email = vm.Email,
                Senha = vm.Senha,
            };

            List<Lista> listaEmail = await ListarEmail();

            //await dbContext.TbLogin.AddAsync(register);
            //await dbContext.SaveChangesAsync();

            return View();
        }

        [HttpGet]
        public async Task<List<Lista>> ListarEmail()
        {
            var emails = await dbContext.TbLogin.ToListAsync();

            return emails;
        }
    }
}
