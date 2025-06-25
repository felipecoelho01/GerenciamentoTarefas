using GerenciamentoTarefas.Models.Entities;
using GerenciamentoTarefas.Services;
using GerenciamentoTarefas.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [Route("Tarefas/Index/{id}")]
        public async Task<IActionResult> Tarefas(int id)
        {
            try
            {
                var listTask = await dbContext.TodoLists.Where(p => p.IdUser == id).OrderByDescending(p => p.dtList).ToListAsync();

                var vmList = new List<DoTarefasViewModel>();

                foreach (var item in listTask)
                {
                    var vm = new DoTarefasViewModel
                    {
                        idList = item.idList,
                        dtList = item.dtList,
                        list_title = item.list_title,
                        list_description = item.list_description,
                        dtConclusion = item.dtConclusion,
                        important = await VerficaPrioridade(item.important),
                        Concluida = item.Concluida,
                    };
                    vmList.Add(vm);
                }

                return View("Tarefas", vmList);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(TarefasEntity vw)
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

            return RedirectToAction();
        }

        [HttpGet]
        public async Task<String> VerficaPrioridade(int prioridade) {
            string text = "";
            if (prioridade == 1)
            {
                text = "Muito Baixa";
            }
            else if (prioridade == 2)
            {
                text = "Baixa";
            }
            else if (prioridade == 3)
            {
                text = "Normal";
            }
            else if (prioridade == 4)
            {
                text = "Alta";
            }
            else if (prioridade == 5)
            {
                text = "Urgente";
            }

            return text;
        }
    }
}
