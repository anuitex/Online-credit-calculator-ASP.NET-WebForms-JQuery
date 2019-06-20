$('.SelectDecisionRequests').click(function () {
    var elem = $(this)[0].parentElement;
    var cellParentElement = elem.parentElement;

    var requestId = $(cellParentElement).attr('id');
    var status = $(this)[0].value;
    var actionName = $(cellParentElement).attr('data-actionname');

    $('#BankContent_hiddenRequestId')[0].textContent = requestId;
    $('#BankContent_hiddenStatus')[0].textContent = status;
    $('#BankContent_hiddenActionName')[0].textContent = actionName;

    if (status === "Decline") {
        $('#declineRequestModal').modal('open');
        return;
    }

    SendDecisionRequests();
});

$(document).ready(function () {
    $('#declineRequestModal').modal();
});


function SendDecisionRequests() {
    $('#declineRequestModal').modal('close');

    var requestId = $('#BankContent_hiddenRequestId')[0].textContent;
    var status = $('#BankContent_hiddenStatus')[0].textContent;
    var actionName = $('#BankContent_hiddenActionName')[0].textContent;
    var description = $('#BankContent_declineRequestDescription')[0].value;
    var parentElem = $('#' + requestId)[0].parentElement;
    $(parentElem).find('.requests-table-status')[0].innerText = status + 'd';

    var model = {   
        'Id': requestId,
        'Status': status + 'd',
        'Description': description
    };

    $.ajax({
        type: "POST",
        url: "Request.aspx/" + actionName,
        data: JSON.stringify({ 'model': model }),
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            alert('Success !');
            $(parentElem).find('.SelectDecisionRequests').css('display', 'none');
            $('#BankContent_declineRequestDescription')[0].value = '';

            window.location.reload(window.location);
        },
        failure: function (response) {
            alert('Error');

            window.location.reload(window.location);
        }
    });
}


