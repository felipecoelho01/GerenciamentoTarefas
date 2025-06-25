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

    $("#saveTask").on("click", function () {
        if (validaTask()) {
            if ($(this).text() === "Editar") {
                editaTarefa($("#taskId").val());
            } else {
                criaTarefa();
            }
        }
    });
});


function criaTarefa() {

}

function editaTarefa(id) {

}

function validaTask() {
    let validate = true;

    if ($("#taskDescription").val().trim() === "") {
        toasterType = { type: 'danger', message: 'Descrição Vazia!' };
        validate = false;
    }

    if ($("#taskTitle").val().trim() === "") {
        toasterType = { type: 'danger', message: 'Título Vazio!' };
        validate = false;
    }

    if (validarData($("#taskDueDate").val())) {
        toasterType = { type: 'danger', message: 'Data Vencimento Inválido!' };
        validate = false;
    }

    return validate;
}

function validarData(dataString) {
    try {
        const data = new Date(dataString);
        if (isNaN(data.getTime())) {
            return false;
        }
        return true;
    } catch (error) {
        return false;
    }
}