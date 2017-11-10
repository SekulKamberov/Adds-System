$(function () {

    var chat = $.connection.chatHub;
    chat.client.getMessage = function (name, message) {
        if (name === $('#user-name').html()) {
            $('#chat-conversation').append('<li id="mine"><b>' + name + '</b>: ' + message + '</li>');
        }
        else{
            $('#chat-conversation').append('<li id="not-mine"><b>' + name + '</b>: ' + message + '</li>');
        }
        $('#chat-conversation').append('</ br>');
    };

    chat.client.getCat = function (name, catUrl) {
        if (name === $('#user-name').html()) {
            $('#chat-conversation').append('<li id="mine">' + name + ':<img class ="img-thumbnail" src="' + catUrl + '" alt="" /> </li>');
        }
        else {
            $('#chat-conversation').append('<li id="not-mine">' + name + ':<img class ="img-thumbnail" src="' + catUrl + '" alt="" /> </li>');
        }
        $('#chat-conversation').append('</ br>');
    };

    chat.client.getVideo = function (name, videoId) {
        if (name === $('#user-name').html()) {
            $('#chat-conversation').append('<li id="mine">' + name + ': <iframe src="https://www.youtube.com/embed/' + videoId + '" frameborder="0" allowfullscreen></iframe></li>');
        }
        else {
            $('#chat-conversation').append('<li id="not-mine">' + name + ': <iframe src="https://www.youtube.com/embed/' + videoId + '" frameborder="0" allowfullscreen></iframe> </li>');
        }
        $('#chat-conversation').append('</ br>');
    }
});