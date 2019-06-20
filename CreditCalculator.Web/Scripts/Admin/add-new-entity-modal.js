$('.admin-add-new-bank-button').click(function () {
    var buttonId = $(this).attr('id');
    $('#modal-container').removeAttr('class').addClass(buttonId);
    $('body').addClass('modal-active');
});

$('.admin-add-new-user-button').click(function () {
    var buttonId = $(this).attr('id');
    $('#modal-container').removeAttr('class').addClass(buttonId);
    $('body').addClass('modal-active');
});


$('.admin-add-new-user-button-cansel').click(function () {
    $('#modal-container').addClass('out');
    $('body').removeClass('modal-active');
});


$('.admin-add-new-bank-button-cansel').click(function () {
    $('#modal-container').addClass('out');
    $('body').removeClass('modal-active');
});

$('.admin-add-new-user-button-register').click(function () {

    var password = $('.admin-add-new-user-info-wrapper #passwordTextBox').val();
    var confirmPassword = $('.admin-add-new-user-info-wrapper #passwordConfirmTextBox').val();

    var model = {
        'FirstName': $('.admin-add-new-user-info-wrapper #firstNameTextBox').val(),
        'LastName': $('.admin-add-new-user-info-wrapper #lastNameTextBox').val(),
        'Email': $('.admin-add-new-user-info-wrapper #emailTextBox').val(),
        'PassportSeries': $('.admin-add-new-user-info-wrapper #passportSeriesTextBox').val(),
        'PassportNumber': $('.admin-add-new-user-info-wrapper #passportNumberTextBox').val(),
        'Address': $('.admin-add-new-user-info-wrapper #addressTextBox').val(),
        'Role': $('.admin-add-new-user-info-wrapper #AdminContent_userRolesDropDown').val(),
        'PhoneNumber': $('.admin-add-new-user-info-wrapper #phoneNumberTextBox').val(),
        'Password': password,
        'UserName': $('.admin-add-new-user-info-wrapper #emailTextBox').val()
    };

    $('#modal-container').addClass('out');
    $('body').removeClass('modal-active');

    $.ajax({
        type: "POST",
        url: "User.aspx/AddNewUser",
        data: JSON.stringify({ 'model': model }),
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.d.Succeeded === true || response.d.success === 'True') {
                alert('Success !');
                window.location.reload(window.location);
            }
            if (response.d.Succeeded === false || response.d.success === 'False') {

                var errors = new Array(response.d.Errors.length);

                var errorsString = "Error : " + response.d.Errors[0];

                alert(errorsString);
            }
        }
    });
});

$('.admin-add-new-bank-button-register').click(function () {

    var model = {
        'Name': $('.admin-add-new-bank-info-wrapper #nameTextBox').val(),
        'AdminId': $('.admin-add-new-bank-info-wrapper #AdminContent_bankAdminDropDown').val(),
        'Information': $('.admin-add-new-bank-info-wrapper #informationTextBox').val(),
        'PhoneNumber': $('.admin-add-new-bank-info-wrapper #phoneNumberTextBox').val(),
        'Country': $('.admin-add-new-bank-info-wrapper #countryTextBox').val(),
        'Address': $('.admin-add-new-bank-info-wrapper #addressTextBox').val(),
        'Email': $('.admin-add-new-bank-info-wrapper #emailTextBox').val()
    };

    if (model.AdminId === '' || model.AdminId === undefined || model.AdminId === null) {
        alert('Select Bank Admin !');

        return;
    }

    $.ajax({
        url: 'Bank.aspx/AddNewBank',
        type: 'POST',
        data: JSON.stringify({ 'model': model }),
        contentType: "application/json; charset=utf-8",
        success: function () {
            alert('Success !');

            window.location.reload(window.location);
        },
        failure: function () {

            alert('Error !');

            window.location.reload(window.location);
        }
    });

    $('#modal-container').addClass('out');
    $('body').removeClass('modal-active');
});
