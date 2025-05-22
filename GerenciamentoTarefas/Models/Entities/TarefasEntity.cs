namespace GerenciamentoTarefas.Models.Entities
{
    public class TarefasEntity
    {
        public Guid idList { get; set; }
        public string list_title { get; set; }
        public string list_description { get; set; }
        public DateTime dtList { get; set; }
        public DateTime dtConclusion { get; set; }
        public int important { get; set; }
        public string Concluida { get; set; }
        public Guid IdUser { get; set; }

    }
}
