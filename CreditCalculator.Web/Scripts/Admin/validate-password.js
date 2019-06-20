$(".passwordTextBox").on("focusout", function (e) {
    if ($(this).val() != $(".passwordConfirmTextBox").val()) {
        $(".passwordConfirmTextBox").removeClass("valid").addClass("invalid");
    } else {
        $(".passwordConfirmTextBox").removeClass("invalid").addClass("valid");
    }
});

$(".passwordConfirmTextBox").on("keyup", function (e) {
    if ($(".passwordTextBox").val() != $(this).val()) {
        $(this).removeClass("valid").addClass("invalid");
    } else {
        $(this).removeClass("invalid").addClass("valid");
    }
});
