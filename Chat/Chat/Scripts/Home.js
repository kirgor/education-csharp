$(ready);

function scroll() {
    $("#messages").scrollTop(100000);
}

function ready() {
    scroll();

    var sessionId = Math.uuid().toLowerCase();
    var lastId = $("#lastIdField").attr("value");
    var userId = $("#idField").attr("value");

    $("#content textarea").keydown(function (e) {
        if (e.which == 13) {
            if (!e.shiftKey) {
                e.preventDefault();
                postMessage();
            }
        }
    });
    $("#submitMessage").click(postMessage);
    $("#content textarea").focus();

    function newMessages() {
        var jqxhr = $.getJSON("/api/message?userId=" + userId + "&lastId=" + lastId);
        jqxhr.done(function (data) {
            for (var i = 0; i < data.length; i++) {
                if (data[i].SessionId != sessionId && data[i].Author != "Alex Ololo") {
                    addMessage(Math.uuid(), data[i].Author, data[i].TimeString, data[i].Text, true);
                    lastId = data[i].Id;
                }
            }
            newMessages();
        });
    }

    newMessages();

    function addMessage(id, author, time, text, delivered) {
        var e = $('<div>', {
            "class": "message" + (delivered ? " delivered" : ""),
            id: id
        });
        e.append($("<div>").text(author + (time != null ? (", " + time) : "")));
        e.append($("<div>").html(text.replace("\n", "<br/>")));
        e.appendTo($('#messages'));

        //$('#messages').append(
        //    "<div class=\"message" + delivered ? " delivered" : "" + "\" id=\"" + id + "\">" +
        //        "<div>" + author + "</div>" +
        //        "<div>" + text + "</div>" +
        //    "</div>");
        scroll();
    }

    function postMessage() {
        var author = $("#authorField").attr("value");
        var time = Date();
        var email = $("#emailField").attr("value");
        var text = $("#messageInput").val();
        var id = Math.uuid();

        addMessage(id, author, null, text, false);

        var jqxhr = $.post("/api/message", {
            email: $("#emailField").attr("value"),
            text: $("#messageInput").val(),
            sessionId: sessionId
        });
        jqxhr.done(function (data) {
            $("#" + id).addClass("delivered");
            $("#" + id + " > div:first-child").append(", " + data);
        });
        jqxhr.fail(function () {
            $("#" + id).addClass("error");
        });

        $("#messageInput").val("");
    }
}