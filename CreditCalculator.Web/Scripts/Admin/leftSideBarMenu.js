$(document).ready(function () {
    var url = window.location;
    var allPath = url.pathname;
    var splitEnd = allPath.split('.aspx');
    var splitStart = splitEnd[0].split('/');
    var neededDirection = splitStart[splitStart.length - 1];
    var menuElements = $('.admin-body .navbar-inverse-admin-page #v-pills-tab').find('a');
    var newElement = $('.admin-body .navbar-inverse-admin-page #v-pills-tab').find('a[data-direction="' + neededDirection +'"]');

    menuElements.removeClass('active');
    $(newElement).addClass('active');
});

function moveToSelectedView(selectedElement) {
    var direction = $(selectedElement).attr('data-direction');

    window.location.replace("/Areas/Admin/" + direction+".aspx");
    activateCssEffect(selectedElement);
}

function activateCssEffect(selectedElement) {
    var menuElements = $('.admin-body .navbar-inverse-admin-page #v-pills-tab').find('a');
    menuElements.removeClass('active');
    $(selectedElement).addClass('active');
}