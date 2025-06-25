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
                        important = item.important,
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
    }
}
