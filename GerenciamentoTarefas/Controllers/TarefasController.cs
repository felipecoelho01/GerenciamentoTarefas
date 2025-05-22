using GerenciamentoTarefas.Models.Entities;
using GerenciamentoTarefas.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoTarefas.Controllers
{
    public class TarefasController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public TarefasController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listTask = await dbContext.TodoLists.FindAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Tarefas vw)
        {
            var Task = await dbContext.TodoLists.FindAsync(vw.idList);

            if (Task is not null)
            {
                Task.list_title = vw.list_title;
                Task.list_description = vw.list_description;
                Task.dtConclusion = vw.dtConclusion;
                Task.important = vw.important;
                Task.Concluida = vw.Concluida;

                await dbContext.SaveChangesAsync();
            }

            return View();
        }
    }
}
