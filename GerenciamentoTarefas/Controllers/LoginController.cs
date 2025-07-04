using GerenciamentoTarefas.Models;
using GerenciamentoTarefas.Models.Entities;
using GerenciamentoTarefas.Services;
using GerenciamentoTarefas.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

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
            return View("Login");
        }

        [HttpPost]
        [Route("login/FazerLogin")]
        public async Task<IActionResult> Login([FromForm] DoLoginViewModel vm)
        {
            var loginList = await dbContext.User_Login
                .Where(login => login.email == vm.Email)
                .ToListAsync();

            if (verificaSenha(vm.Senha, loginList.First().senhaHash, loginList.First().senhaSalt))
            {
                return Json(new { success = true, message = "Login Realizado!" });
            }
            else
            {
                return Json(new { success = false, message = "Email não cadastrado!" });
            }
        }

        public bool verificaSenha(string senhaDigitada, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senhaDigitada));
                return computedHash.SequenceEqual(storedHash); 
            }
        }
    }
}
