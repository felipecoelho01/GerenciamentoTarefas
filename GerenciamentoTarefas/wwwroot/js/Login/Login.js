$(function () {
    $('#loginForm').on('submit', function (e) {
        e.preventDefault();
        if (validateLogin()) {
            formSubmit(this);
        }
    });
});

function validateLogin() {
    let validate = true;

    if ($("#iptEmailLogin").val().trim() === "") {
        validate = false;
        showToast({ type: 'danger', message: 'Campo "Email" vazio!' })
    }

    if ($("#iptSenhaLogin").val().trim() === "") {
        validate = false;
        showToast({ type: 'danger', message: 'Campo "Senha" vazio!' })
    }

    return validate;
}

function formSubmit(form) {
    $.ajax({
        url: '/login/FazerLogin',
        type: 'POST',
        data: $(form).serialize(),
        success: function (response) {
            showToast({ type: 'success', message: response.message });

            setTimeout(() => {

            });
        },
        error: function (xhr, status, error) {
            showToast({ type: 'danger', message: error });
        }
    });
}