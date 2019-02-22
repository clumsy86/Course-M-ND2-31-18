"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/commentHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (message, hash, commentId) {
    if (message != "") {
        var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
        var username = document.getElementById("userName").value;
        if (username == "") {
            alert("Please LogIn")
        }
        else {
            var template = $('#hidden-template').html();
            var item = $(template).clone();
            $(item).find('#content').html(msg);
            var button = $(item).find('#buttonId');
            button.attr('id', hash.toString());
            var comment = $(item).find('#commentId');
            var str = commentId.toString();
            comment.val(str);
            comment.attr('id', "commentId" + " " + hash.toString());
            var count = $(item).find('#commentId');
            count.attr('id', "count" + " " + hash.toString());
            $('#target').append(item);
            document.getElementById('messageInput').value = "";
        }
    }
    else {
        return;
    }
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = document.getElementById("messageInput").value;
    var postId = document.getElementById("postId").value;
    var userId = document.getElementById("userId").value;
    connection.invoke("SendMessage", message, postId, userId).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});