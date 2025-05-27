$(function () {
    $('#registerForm').submit(function (e) {
        e.preventDefault(); 

        $.ajax({
            url: '@Url.Action("RegisterUser", "register")',
            type: 'POST',
            data: $(this).serialize(),
            success: function (response) {
                $('#resultado').html('Dados enviados com sucesso!');
                console.log(response);
            },
            error: function (xhr, status, error) {
                $('#resultado').html('Ocorreu um erro: ' + error);
            }
        });
    });
});