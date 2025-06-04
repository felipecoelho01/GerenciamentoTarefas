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

            });
        },
        error: function (xhr, status, error) {
            showToast({ type: 'danger', message: error });
        }
    });
}