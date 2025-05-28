$(function () {
    $('#registerForm').on('submit', function (e) {
        e.preventDefault();
        if (validateRegister()) {
            formSubmit(this);
        }
    });

    $('#iptConfirm').on("change", function () {
        if ($(this).val().trim() !== $("#iptSenha").val().trim()) {
            $("#textWrong").show();
        } else {
            ("#textWrong").hide();
        }
    });
});

function validateRegister() {
    let validate = true;
    let toasterType;

    if ($("#iptNome").val().trim() === "") {
        toasterType = { type: 'danger', message: 'Campo "nome" está vazio!' };
        validate = false;
    }

    if ($("#iptEmail").val().trim() === "") {
        toasterType = { type: 'danger', message: 'Campo "email" está vazio!' }
        validate = false;
    }

    if ($("#iptSenha").val().trim() === "") {
        toasterType = { type: 'danger', message: 'Campo "senha" está vazio!' }
        validate = false;
    }

    if ($("#iptConfirm").val().trim() === "") {
        toasterType = { type: 'danger', message: 'Campo "confirmar senha" está vazio!' }
        validate = false;
    }

    if (!validate) {
        showToast(toasterType)
    }
    return validate;
}

function formSubmit(form) {
    $.ajax({
        url: '@Url.Action("RegisterUser", "register")',
        type: 'POST',
        data: $(form).serialize(),
        success: function (response) {
            $('#resultado').html('Dados enviados com sucesso!');
            console.log(response);
        },
        error: function (xhr, status, error) {
            $('#resultado').html('Ocorreu um erro: ' + error);
        }
    });
}