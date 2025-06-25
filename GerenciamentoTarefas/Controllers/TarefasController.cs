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
        [Route("Tarefas/editar")]
        public async Task<IActionResult> Edit([FromForm] TarefasEntity vw)
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

        [HttpPost]
        [Route("Tarefas/criar")]
        public async Task<IActionResult> Create([FromForm] TarefasEntity vw)
        {
            try
            {
                var Task = new TarefasEntity
                {
                    list_title = vw.list_title,
                    list_description = vw.list_description,
                    dtConclusion = vw.dtConclusion,
                    dtList = DateTime.Now,
                    important = vw.important,
                    Concluida = vw.Concluida,
                };

                await dbContext.TodoLists.AddAsync(Task);
                await dbContext.SaveChangesAsync();

                return Json(new { success = true, message = "Tarefa criada com Sucesso!" });
            }
            catch (Exception ex) {
                return Json(new { success = false, message = ex });
            }
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
