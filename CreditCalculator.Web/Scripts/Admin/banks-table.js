$(document).ready(function () {
    var t = $('#admin-banks-table').DataTable({
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

function editBankModal(e) {
    var bankId = $(e).attr('data-bank-id');
    var rows = $('#admin-banks-table')[0];
    var selectedRow = $(rows).find("tr[data-bank-id='" + bankId + "']");

    $('#edit-bank-modal-container #AdminContent_hiddenBankId')[0].innerText = bankId;
    $('#edit-bank-modal-container #editBankNameTextBox')[0].value = $(selectedRow).find("td[class='bankName']")[0].innerText;
    $('#edit-bank-modal-container #editBankInformationTextBox')[0].value = $(selectedRow).find("td[class='bankInformation']")[0].innerText;
    $('#edit-bank-modal-container #editBankPhoneNumberTextBox')[0].value = $(selectedRow).find("td[class='bankPhoneNumber']")[0].innerText;
    $('#edit-bank-modal-container #editBankCountryTextBox')[0].value = $(selectedRow).find("td[class='bankCountry']")[0].innerText;
    $('#edit-bank-modal-container #editBankAddressTextBox')[0].value = $(selectedRow).find("td[class='bankAddress']")[0].innerText;
    $('#edit-bank-modal-container').removeAttr('class').addClass('one');
    $('body').addClass('modal-active');
}

$('.edit-bank-button-cansel').click(function () {
    $('#edit-bank-modal-container').addClass('out');
    $('body').removeClass('modal-active');
});

$('.edit-bank-button-register').click(function () {

    var model = {
        'Id': $('#edit-bank-modal-container #AdminContent_hiddenBankId')[0].innerText,
        'Name': $('#edit-bank-modal-container #editBankNameTextBox')[0].value,
        'Information': $('#edit-bank-modal-container #editBankInformationTextBox')[0].value,
        'PhoneNumber': $('#edit-bank-modal-container #editBankPhoneNumberTextBox')[0].value,
        'Country': $('#edit-bank-modal-container #editBankCountryTextBox')[0].value,
        'Address': $('#edit-bank-modal-container #editBankAddressTextBox')[0].value
    };

    $.ajax({
        url: 'Bank.aspx/UpdateBank',
        type: 'POST',
        data: JSON.stringify({ 'model': model }),
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            alert('Success !');

            window.location.reload(window.location);
        },
        failure: function () {
            alert('Error !');
        }
    });
});

$(document).ready(function () {
    $('#deleteBankModal').modal();
});

function deleteBankModal(e) {
    $('#AdminContent_hiddenDeleteBankId')[0].innerText = $(e).attr('data-bank-id');
    $('#AdminContent_hiddenDeleteAdminId')[0].innerText = $(e).attr('data-admin-id');
    $('#deleteBankModal').modal('open');
}

function confirmDeleteBank() {
    var bankId = $('#AdminContent_hiddenDeleteBankId')[0].innerText;
    var adminId = $('#AdminContent_hiddenDeleteAdminId')[0].innerText;
    
    $.ajax({
        type: "POST",
        url: "Bank.aspx/DeleteBank",
        data: JSON.stringify({ 'bankId': bankId, 'adminId': adminId }),
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
