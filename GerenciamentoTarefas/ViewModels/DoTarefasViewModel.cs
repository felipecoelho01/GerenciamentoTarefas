using GerenciamentoTarefas.Models.Entities;

namespace GerenciamentoTarefas.ViewModels
{
    public class DoTarefasViewModel
    {
        public int idList { get; set; }
        public string list_title { get; set; }
        public string list_description { get; set; }
        public DateTime dtList { get; set; }
        public DateTime dtConclusion { get; set; }
        public string important { get; set; }
        public bool Concluida { get; set; }
        public int IdUser { get; set; }

        public List<TarefasEntity> listaTaks { get; set; }
    }
}
