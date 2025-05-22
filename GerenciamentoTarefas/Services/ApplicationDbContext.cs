using GerenciamentoTarefas.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoTarefas.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ListaEntity> TbLogin { get; set; }
        public DbSet<TarefasEntity> TodoLists { get; set; }
    }
}
