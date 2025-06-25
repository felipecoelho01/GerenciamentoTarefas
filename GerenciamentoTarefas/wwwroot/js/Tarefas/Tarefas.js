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

    $("#taskForm").on("submit", function (e) {
        e.preventDefault();
        if (validaTask()) {
            if ($(this).text() === "Editar") {
                editaTarefa(this);
            } else {
                criaTarefa(this);
            }
        }
    });
});


function criaTarefa(form) {
    $.ajax({
        url: '/Tarefas/criar',
        type: 'POST',
        data: $(form).serialize(),
        success: function (response) {
            showToast({ type: 'success', message: response.message });

            setTimeout(() => {
                //window.location.href = '/Login/Login';
            }, 3000);
        },
        error: function (xhr, status, error) {
            showToast({ type: 'danger', message: error });
        }
    });
}

function editaTarefa(form) {
    $.ajax({
        url: '/Tarefas/editar',
        type: 'POST',
        data: $(form).serialize(),
        success: function (response) {
            showToast({ type: 'success', message: response.message });

            setTimeout(() => {
                //window.location.href = '/Login/Login';
            }, 3000);
        },
        error: function (xhr, status, error) {
            showToast({ type: 'danger', message: error });
        }
    });
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