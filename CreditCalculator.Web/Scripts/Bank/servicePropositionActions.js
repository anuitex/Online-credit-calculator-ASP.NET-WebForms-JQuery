$(document).ready(function () {
    $('#editServicePropositionModal').modal();
});

$(document).ready(function () {
    $('#addServicePropositionModal').modal();
    $('#addServicePropositionModal').css('display', 'none');
});

$(document).ready(function () {
    $('#deleteServicePropositionModal').modal();
    $('#deleteServicePropositionModal').css('display', 'none');
});

function editPropositionModal(e) {
    var propositionId = $(e).attr('id');
    var selectedRow = $('.bank-services-menu-elements-wrapper').find('table').find("tr[data-proposition-id='" + propositionId + "']");

    $('#editServicePropositionModal #BankContent_hiddenPropositionId')[0].innerText = $(e).attr('id');
    $('#editServicePropositionModal #BankContent_hiddenBankId')[0].innerText = $(selectedRow).find("td.propositions-table-bank-id")[0].innerText;
    $('.modal-content-wrapper #dataTextBox')[0].value = $(selectedRow).find("td.propositions-table-creation-date")[0].innerText;
    $('.modal-content-wrapper #BankContent_editPropositionTitleDropDown')[0].value = $(selectedRow).find("td.propositions-table-title")[0].innerText;
    $('.modal-content-wrapper input#subTitleTextBox')[0].value = $(selectedRow).find("td.propositions-table-sub-title")[0].innerText;
    $('.modal-content-wrapper input#minBetCreditTextBox')[0].value = $(selectedRow).find("td.propositions-table-credit-min-bet .value")[0].innerText;
    $('.modal-content-wrapper input#maxBetCreditTextBox')[0].value = $(selectedRow).find("td.propositions-table-credit-max-bet .value")[0].innerText;
    $('.modal-content-wrapper input#minBetDepositTextBox')[0].value = $(selectedRow).find("td.propositions-table-deposit-min-bet .value")[0].innerText;
    $('.modal-content-wrapper input#maxBetDepositTextBox')[0].value = $(selectedRow).find("td.propositions-table-deposit-max-bet .value")[0].innerText;

    $('#editServicePropositionModal').modal('open');
}

function sendUpdatePropositionData() {
    var model = {
        'Id': $('#editServicePropositionModal #BankContent_hiddenPropositionId')[0].innerText,
        'BankId': $('#editServicePropositionModal #BankContent_hiddenBankId')[0].innerText,
        'CreationDate': $('.modal-content-wrapper #dataTextBox')[0].value,
        'Title': $('.modal-content-wrapper #BankContent_editPropositionTitleDropDown')[0].value,
        'SubTitle': $('.modal-content-wrapper input#subTitleTextBox')[0].value,
        'MinBetCredit': $('.modal-content-wrapper input#minBetCreditTextBox')[0].value,
        'MaxBetCredit': $('.modal-content-wrapper input#maxBetCreditTextBox')[0].value,
        'MinBetDeposit': $('.modal-content-wrapper input#minBetDepositTextBox')[0].value,
        'MaxBetDeposit': $('.modal-content-wrapper input#maxBetDepositTextBox')[0].value
    };
    
    $.ajax({
        type: "POST",
        url: "Services.aspx/UpdateBankProposition",
        data: JSON.stringify({ 'model': model }),
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

function closeAddPropositionModal() {
    $('#addServicePropositionModal').css('display', 'none');
}

function showAddPropositionModal() {
    $('#addServicePropositionModal').modal('open');
}

function addProposition() {
    var model = {
        'Bankid': $("#BankContent_addServicePropositionHiddenBankId")[0].innerText,
        'Title': $('#addServicePropositionModal #BankContent_addPropositionTitleDropDown')[0].value,
        'Subtitle': $('#addServicePropositionModal #addPropositionSubTitleTextBox')[0].value,
        'Minbetcredit': $('#addServicePropositionModal #addPropositionMinBetCreditTextBox')[0].value,
        'Maxbetcredit': $('#addServicePropositionModal #addPropositionMaxBetCreditTextBox')[0].value,
        'Minbetdeposit': $('#addServicePropositionModal #addPropositionMinBetDepositTextBox')[0].value,
        'Maxbetdeposit': $('#addServicePropositionModal #addPropositionMaxBetDepositTextBox')[0].value
    };
    
    $.ajax({
        type: "POST",
        url: "Services.aspx/AddBankProposition",
        data: JSON.stringify({ 'model': model }),
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            alert('Ok !');

            window.location.reload(window.location);
        },
        failure: function (response) {
            alert('Error');
        }
    });

    $('#addServicePropositionModal').css('display', 'none');
}

function deletePropositionModal(e) {
    $('#BankContent_hiddenDeletePropositionId')[0].innerText = $(e).attr('data-proposition-id');
    $('#deleteServicePropositionModal').modal('open');
}

function confirmDeleteProposition() {
    var propositionId = $('#BankContent_hiddenDeletePropositionId')[0].innerText;
    
    $.ajax({
        type: "POST",
        url: "Services.aspx/DeleteBankProposition",
        data: JSON.stringify({ 'propositionId': propositionId }),
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
