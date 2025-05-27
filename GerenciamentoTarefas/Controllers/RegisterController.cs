using GerenciamentoTarefas.Models;
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

        [Route("register/Index")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("register/RegisterUser")]
        public async Task<IActionResult> Register(DoRegisterViewModel vm)
        {

            if (vm.Senha != vm.SenhaConfirm || Convert.ToBoolean(VerifyEmail(vm.Email)))
            {
                return Json(new { success = false, message = "Erro de validação" });
            }

            var register = new ListaEntity
            {
                Email = vm.Email,
                Senha = vm.Senha,
            };

            await dbContext.TbLogin.AddAsync(register);
            await dbContext.SaveChangesAsync();

            return Json(new { success = true, message = "Dados recebidos!" });
        }

        [HttpGet]
        public async Task<Boolean> VerifyEmail(String email)
        {
            var emails = await dbContext.TbLogin.Where(emails => emails.Email == email).ToListAsync();

            return emails.Count != 0;
        }
    }
}
