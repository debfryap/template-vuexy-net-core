$('.input-otp').keyup(function () {
    if ($(this).val().length == 4) {
        $(this).blur();
    }
})

var verified = $('#verify').validate({
    rules: {
        otp: {
            required: true,
            digits: true,
        }
    },
    errorElement: "span"
});
function verify(dom) {
    var form = $(dom);
    var data = JSON.parse('{"' + decodeURI(form.serialize()).replace(/"/g, '\\"').replace(/&/g, '","').replace(/=/g, '":"') + '"}');
    if ($('#verify').valid()) {
        $.post(form.attr('action'), data, function (res) {

            if (res.status == 'error') {
                verified.showErrors({
                    "otp": res.message
                });
            } else {
                $.get(base_url + '/verification/createpassword', function (response) {
                    $('#verification').html(response);
                });
            }
        });
    }

    event.preventDefault();
}
function reSend() {
    alert('resend email');
    event.preventDefault();
}