$('#btnContactUs').click(function () {
    $('#btnContactUs').attr('disabled', true);
    var touchData = {
        Name: $('#name').val(),
        Email: $('#email').val(),
        Subject: $('#subject').val(),
        Msg: $('#msg').val(),

    }
    $.ajax({
        url: "https://chenscode.azurewebsites.net/api/SendMessage",
        type: "POST",
        data: JSON.stringify(touchData),
        crossDomain: true,
        dataType: "text",
        contentType: "application/json;charset=utf-8",
        success: function () {
            alert("感謝您的建議，我們將會盡速回覆");
            $('#name').val("");
            $('#email').val("");
            $('#subject').val("");
            $('#msg').val("");
            $('#btnContactUs').attr('disabled', false);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
        },
    });
    //$.ajax({
    //    url: "https://chenscode.azurewebsites.net/WeatherForecast",
    //    type: "GET",
    //    success: function () {
    //        alert("YES");
    //    },
    //    error: function (xhr, ajaxOptions, thrownError) {
    //        alert(xhr.status);
    //    }
    //})
});