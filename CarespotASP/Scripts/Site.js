$(document).ready(function () {
    $('#example').DataTable();


    SendChatMessageOnClick();
    ShowVrijwilliger();
    HideVrijwilliger();
      setInterval(function () {
          FillChatBoxIfPossible();
      }, 3000);

});



function FillChatBoxIfPossible() {
    var url = window.location.href;
    var urlArray = url.split("/");
    if (urlArray[3] == "Chat" && typeof urlArray[4] != 'undefined') {

        $.post("/Chat/HaalChatOp", { userId1: $("#loggedUserId").val(), userId2: urlArray[4] })
            .done(function (data) {
                var chatString = "";
                console.log(data);
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

          $.post("/Chat/SendChatMessage", { autheurId: $("#loggedUserId").val(), ontvangerId: urlArray[4], bericht: chatBericht});
        }

        $("#chatBericht").val("");
        FillChatBoxIfPossible();


    });
}

function HideVrijwilliger() {
    
    $("#vog").addClass("hidden");
    $("#vaardigheid").addClass("hidden");
   
}
var count = 0;
function ShowVrijwilliger() {

    $('#vrij').click(function () {
        var checkboxResult = this.checked;
      
        var checked = $('#vrij').prop('checked');
        if (checked) {
            if (count === 0) {
                alert(checked + "eerste");
                $("#vog").removeClass("hidden");
                $("#vaardigheid").removeClass("hidden");
                $("#voginput").prop('required', true);
                count ++;
            }
            else if (count > 0) {
                alert(checked + "tweede");
                $("#vog").addClass("hidden");
                $("#vaardigheid").addClass("hidden");
                $("#voginput").prop('required', false);
                $(this).prop('checked', false);  
                count = 0;
            }
          
        } 
    });
 //als die niet checked is - on click -> true
// als die checked is -  onclick -> false
}




