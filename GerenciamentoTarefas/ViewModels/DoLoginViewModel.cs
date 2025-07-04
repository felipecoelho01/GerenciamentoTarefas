using System.ComponentModel.DataAnnotations;

namespace GerenciamentoTarefas.ViewModels
{
    public class DoLoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
