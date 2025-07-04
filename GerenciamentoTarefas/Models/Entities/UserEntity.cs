using System.ComponentModel.DataAnnotations;

namespace GerenciamentoTarefas.Models.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string nome { get; set; }
        [Required]
        public byte[] senhaHash { get; set; }
        [Required]
        public byte[] senhaSalt { get; set; }
    }
}
