using System.Security.Cryptography;
using System.Text;
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

                CreatePasswordHash(vm.Senha, out byte[] hash, out byte[] salt);

                var register = new UserEntity
                {
                    email = vm.Email,
                    nome = vm.NomeCompleto,
                    senhaHash = hash,
                    senhaSalt = salt,
                };

                await dbContext.User_Login.AddAsync(register);
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
                var emailExists = await dbContext.User_Login.AnyAsync(emails => emails.email == email);

                return emailExists;
            }
            catch (Exception ex)
            {
                var erro = ex;
            }

            return false;
        }

        [HttpGet]
        public static void CreatePasswordHash(string password, out byte[] passwordSalt, out byte[] passwordHash)
        {
            using (var hmac = new HMACSHA512()) 
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            }
        }
    }
}
