$(document).ready(function (e) {
    $(this).toggleClass('navicon--active');
    $('.toggle').toggleClass('toggle--active');


    $('.navicon').on('click', function (e) {
        $(this).toggleClass('navicon--active');
        $('.toggle').toggleClass('toggle--active');
    });
});
