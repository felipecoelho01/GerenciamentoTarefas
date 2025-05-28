// Tipos disponíveis
//showToast({ type: 'info', message: 'Informação importante.' });
//showToast({ type: 'success', message: 'Sucesso na operação.' });
//showToast({ type: 'warning', message: 'Atenção necessário.' });
//showToast({ type: 'danger', message: 'Ocorreu um erro.' });

function showToast(options) {
    // Configurações padrão
    const defaults = {
        title: 'Notificação',
        message: 'Esta é uma mensagem de toast.',
        type: 'info', 
        delay: 5000, 
        autohide: true
    };

    const settings = $.extend({}, defaults, options);

    const toastId = 'toast-' + Date.now();
    const toast = $(`
        <div id="${toastId}" class="toast" role="alert" aria-live="assertive" aria-atomic="true" data-bs-delay="${settings.delay}" data-bs-autohide="${settings.autohide}">
            <div class="toast-header">
                <strong class="me-auto">${settings.title}</strong>
                <small class="text-muted">Agora</small>
                <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
            </div>
            <div class="toast-body">
                ${settings.message}
            </div>
        </div>
    `);

    if (settings.type) {
        toast.find('.toast-header').addClass('bg-' + settings.type + ' text-white');
        toast.find('.btn-close').addClass('btn-close-white');
    }

    $('#toastContainer').append(toast);

    const bsToast = new bootstrap.Toast(toast[0]);
    bsToast.show();

    toast.on('hidden.bs.toast', function () {
        $(this).remove();
    });

    return toast;
}