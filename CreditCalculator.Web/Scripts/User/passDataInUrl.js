$('.bank-refference').click(function () {
    var bankId = $(this).attr('data-bankId');
    var bankName = $(this)[0].text;

    window.location.replace("/Areas/User/Bank.aspx?bankId=" + bankId);

});

$('.services-refference').click(function () {

    function GetParametr(key) {
        key = key.replace(/[*+?^$.\[\]{}()|\\\/]/g, "\\$&");
        var match = location.search.match(new RegExp("[?&]" + key + "=([^&]+)(&|$)"));
        return match && decodeURIComponent(match[1].replace(/\+/g, " "));
    }

    var bankId = GetParametr('bankId');
    var bankName = GetParametr('bankName');

    window.location.replace("/Areas/User/BankServices.aspx?bankId=" + bankId);
});

$('.move-with-parameters-refference').click(function () {
    function GetParametr(key) {
        key = key.replace(/[*+?^$.\[\]{}()|\\\/]/g, "\\$&");
        var match = location.search.match(new RegExp("[?&]" + key + "=([^&]+)(&|$)"));
        return match && decodeURIComponent(match[1].replace(/\+/g, " "));
    }

    var bankId = GetParametr('bankId');
    var bankName = GetParametr('bankName');

    var bankDirection = $(this).attr('data-service-name');

    window.location.replace("/Areas/User/" + bankDirection + ".aspx?bankId=" + bankId);
});
