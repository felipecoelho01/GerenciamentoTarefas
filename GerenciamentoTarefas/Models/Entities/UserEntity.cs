using System.ComponentModel.DataAnnotations;

namespace GerenciamentoTarefas.Models.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
    }
}
