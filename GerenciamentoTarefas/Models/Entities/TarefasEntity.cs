using System.ComponentModel.DataAnnotations;

namespace GerenciamentoTarefas.Models.Entities
{
    public class TarefasEntity
    {
        [Key]
        public int idList { get; set; }
        public string list_title { get; set; }
        public string list_description { get; set; }
        public DateTime dtList { get; set; }
        public DateTime dtConclusion { get; set; }
        public int important { get; set; }
        public bool Concluida { get; set; }
        public int id_user { get; set; }

    }
}
