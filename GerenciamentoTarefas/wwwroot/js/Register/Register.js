$(function () {
    $('#registerForm').on('submit', function (e) {
        e.preventDefault();
        if (validateRegister()) {
            formSubmit(this);
        }
    });

    $('#iptConfirm').on("keyup", function () {
        if ($(this).val().trim() !== $("#iptSenha").val().trim()) {
            $("#textWrong").removeClass("visually-hidden");
        } else {
            $("#textWrong").addClass("visually-hidden");
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
        toasterType = { type: 'danger', message: 'Campo "email" está vazio!' };
        validate = false;
    }

    if ($("#iptSenha").val().trim() === "") {
        toasterType = { type: 'danger', message: 'Campo "senha" está vazio!' };
        validate = false;
    }

    if ($("#iptConfirm").val().trim() === "") {
        toasterType = { type: 'danger', message: 'Campo "confirmar senha" está vazio!' };
        validate = false;
    }

    if ($("#iptConfirm").val().trim() !== $("#iptSenha").val().trim()) {
        toasterType = { type: 'danger', message: 'Os campos não coincidem!' };
        validate = false;
    }

    if (!validate) {
        showToast(toasterType);
    }
    return validate;
}

function formSubmit(form) {
    $.ajax({
        url: '/register/RegisterUser',
        type: 'POST',
        data: $(form).serialize(),
        success: function (response) {
            showToast({ type: 'success', message: response.message });

            setTimeout(() => {
                window.location.href = '/Login/Login';
            }, 3000);
        },
        error: function (xhr, status, error) {
            showToast({ type: 'danger', message: error });
        }
    });
}