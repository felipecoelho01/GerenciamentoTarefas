using GerenciamentoTarefas.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoTarefas.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TarefasEntity>().HasKey(t => t.idList);
            modelBuilder.Entity<UserEntity>().HasKey(t => t.Id);

            base.OnModelCreating(modelBuilder);
        }



        public DbSet<UserEntity> TbLogin { get; set; }
        public DbSet<TarefasEntity> ListaToDo { get; set; }
    }
}
