$(document).ready(function () {
    SendChatMessageOnClick();

    setInterval(function () {
        FillChatBoxIfPossible();
    }, 3000);

    $("#example").DataTable();
    $("#opdrachten").DataTable();
    $("#vog").DataTable();
    $("#gebruikers").DataTable();
});

function FillChatBoxIfPossible() {
    var url = window.location.href;
    var urlArray = url.split("/");
    if (urlArray[3] == "Chat" && typeof urlArray[4] != 'undefined') {
        $.post("/Chat/HaalChatOp", { userId1: $("#loggedUserId").val(), userId2: urlArray[4] })
            .done(function (data) {
                var chatString = "";
                for (var i = 0; i < data.length; i++) {
                    chatString = chatString + data[i].Auteur.Naam + " |  " + data[i].Bericht + "\r";
                }

                if (chatString == "") {
                    chatString = "Er zijn nog geen chatberichten.";
                }

                $('#chatBerichten').val(chatString);
            });
    }
}

function SendChatMessageOnClick() {
    $("#sendChat").click(function () {
        var url = window.location.href;
        var urlArray = url.split("/");
        var chatBericht = $("#chatBericht").val();
        if (urlArray[3] == "Chat" && typeof urlArray[4] != 'undefined') {
            $.post("/Chat/SendChatMessage", { autheurId: $("#loggedUserId").val(), ontvangerId: urlArray[4], bericht: chatBericht });
        }

        $("#chatBericht").val("");
        FillChatBoxIfPossible();
    });
}