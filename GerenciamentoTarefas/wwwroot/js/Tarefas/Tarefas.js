$(function () {
    $("#btnNovaTarefa").on("click", function () {
        $("#taskModalLabel").text("Nova Tarefa");
        $("#saveTask").text("Criar");
        $("#taskModal").modal("show");
    });

    $(".btnEditar").on("click", function () {
        const valorId = $(this).attr("data-item-id");
        $("#taskId").val(valorId);
        $("#saveTask").text("Editar");
        $("#taskModalLabel").text("Editar Tarefa");
        $("#taskModal").modal("show");
    });

    $(".btnExcluir").on("click", function () {
        const valorId = $(this).attr("data-item-id");
        $("#taskIdExcluir").val(valorId);
        $("#taskModalTitle").text(`Deseja mesmo excluir a tarefa "${$(this).attr('data-item-titulo')}"?`);
        $("#taskRemoveModal").modal("show");
    });
});