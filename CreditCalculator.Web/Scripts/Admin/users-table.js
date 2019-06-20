$(document).ready(function () {
    var t = $('#admin-users-table').DataTable({
        "scrollY": "600px",
        "scrollX": true,
        "scrollCollapse": true,
        fixedColumns: {
            heightMatch: 'none'
        },

        "columnDefs": [{
            "searchable": false,
            "orderable": false,
            "targets": 0
        },
        {
            "width": "5%", "targets": 0
        }
        ],
        "ordering": false
    });

    t.on('order.dt search.dt', function () {
        t.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();
});

function editUserModal(e) {
    var userId = $(e).attr('data-user-id');
    var rows = $('#admin-users-table')[0];
    var selectedRow = $(rows).find("tr[data-user-id='" + userId + "']");

    $('#edit-user-modal-container #AdminContent_hiddenUserId')[0].innerText = userId;

    $('#edit-user-modal-container #editUserFirstNameTextBox')[0].value = $(selectedRow).find("span[class='user-first-name']")[0].innerText;
    $('#edit-user-modal-container #editUserLastNameTextBox')[0].value = $(selectedRow).find("span[class='user-last-name']")[0].innerText;
    $('#edit-user-modal-container #editUserEmailTextBox')[0].value = $(selectedRow).find("td[class='userEmail']")[0].innerText;
    $('#edit-user-modal-container #editUserPassportSeriesTextBox')[0].value = $(selectedRow).find("td[class='userPassportSeries']")[0].innerText;
    $('#edit-user-modal-container #editUserPassportNumberTextBox')[0].value = $(selectedRow).find("td[class='userPassportNumber']")[0].innerText;
    $('#edit-user-modal-container #editUserAddressTextBox')[0].value = $(selectedRow).find("td[class='userAddress']")[0].innerText;
    $('#edit-user-modal-container #editUserPhoneNumberTextBox')[0].value = $(selectedRow).find("td[class='userPhoneNumber']")[0].innerText;

    $('#edit-user-modal-container').removeAttr('class').addClass('one');
    $('body').addClass('modal-active');
}

$('.admin-edit-user-button-cansel').click(function () {
    $('#edit-user-modal-container').addClass('out');
    $('body').removeClass('modal-active');
});

$('.admin-edit-user-button-save').click(function () {
    var model = {
        'Id': $('#edit-user-modal-container #AdminContent_hiddenUserId')[0].innerText,
        'FirstName': $('#edit-user-modal-container #editUserFirstNameTextBox')[0].value,
        'LastName': $('#edit-user-modal-container #editUserLastNameTextBox')[0].value,
        'Email': $('#edit-user-modal-container #editUserEmailTextBox')[0].value,
        'PassportSeries': $('#edit-user-modal-container #editUserPassportSeriesTextBox')[0].value,
        'PassportNumber': $('#edit-user-modal-container #editUserPassportNumberTextBox')[0].value,
        'Address': $('#edit-user-modal-container #editUserAddressTextBox')[0].value,
        'PhoneNumber': $('#edit-user-modal-container #editUserPhoneNumberTextBox')[0].value
    };

    $('#edit-user-modal-container').addClass('out');
    $('body').removeClass('modal-active');

    $.ajax({
        type: "POST",
        url: "User.aspx/UpdateUser",
        data: JSON.stringify({ 'model': model }),
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            alert('Success !');

                window.location.reload(window.location);
        },

        failure: function (response) {
            alert('Error');
        }
    });
});

function deleteUserModal(e) {
    $('#AdminContent_hiddenDeleteUserId')[0].innerText = $(e).attr('data-user-id');

    $('#deleteUserModal').modal('open');  
}

function closeDeleteUserModal() {
    $('#addServicePropositionModal').css('display', 'none');
}

$(document).ready(function () {
    $('#deleteUserModal').modal();
});

function confirmDeleteUser() {
    var userId = $('#AdminContent_hiddenDeleteUserId')[0].innerText;

    $('#edit-bank-modal-container').addClass('out');
    $('body').removeClass('modal-active');
    $('#deleteUserModal').css('display', 'none'); 
    
    $.ajax({
        type: "POST",
        url: "User.aspx/DeleteUser",
        data: JSON.stringify({ 'userId': userId }),
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            alert('Ok !');

            window.location.reload(window.location);
        },
        failure: function (response) {
            alert('Error');
        }
    });
}
