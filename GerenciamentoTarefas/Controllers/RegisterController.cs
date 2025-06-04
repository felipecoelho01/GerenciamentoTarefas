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
        public async Task<IActionResult> Register([FromForm] DoRegisterViewModel vm)
        {
            try
            {
                if (vm.Senha != vm.SenhaConfirm || await VerifyEmail(vm.Email))
                {
                    return Json(new { success = false, message = "Erro de validação" });
                }

                var register = new UserEntity
                {
                    Email = vm.Email,
                    Senha = vm.Senha,
                    Nome = vm.NomeCompleto
                };

                await dbContext.TbLogin.AddAsync(register);
                await dbContext.SaveChangesAsync();

                return Json(new { success = true, message = "Registro Realizado!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex });
            }

        }

        [HttpGet]
        public async Task<Boolean> VerifyEmail(String email)
        {
            try
            {
                var emailExists = await dbContext.TbLogin.AnyAsync(emails => emails.Email == email);

                return emailExists;
            }
            catch (Exception ex)
            {
                var erro = ex;
            }

            return false;
        }
    }
}
