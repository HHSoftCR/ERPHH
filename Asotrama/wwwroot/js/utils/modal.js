export function openModal() {
    $('#modal').css('display', 'block');
}

export function closeModal() {
    $('#modal').css('display', 'none');
}

export function navigateModalOptions() {
    $('.sidebar-item').click(function () {
        var category = $(this).data('category');

        $('.options-box').addClass('hidden');

        $('#' + category + '-options').removeClass('hidden');

        console.log("Category clicked: " + category)
    });

    $('.configuration-icon').click(function () {
        $('.modal').css('display', 'block');
    });

    $('.modal .close').click(function () {
        $('.modal').css('display', 'none');
    });

    $('.sidebar-item').click(function () {
        $('.sidebar-item').removeClass('active');

        $(this).addClass('active');

        const index = $(this).index();

        $('.option-content').removeClass('active');

        $('.option-content').eq(index).addClass('active');
    });
}



$(document).ready(function () {
    $('.configuration-icon').click(function () {
        openModal();
    });

    $('.modal').click(function (event) {
        if ($(event.target).hasClass('modal')) {
            closeModal();
        }
    });

    $('.close').click(function () {
        closeModal();
    });

    navigateModalOptions();

});
