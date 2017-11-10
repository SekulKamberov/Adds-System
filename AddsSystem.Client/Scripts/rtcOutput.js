$(function() {
    var chat = $.connection.chatHub;
    $.connection.hub.start().done(function () {
        $('#send-message').click(function () {
            chat.server.getMessage($('#user-name')
                .html(), $('#message').val());
        });
    });

    $('#send-cat').click(function () {
        chat.server.getCat($('#user-name').html());
    });

    $('#search-button').click(function () {
        chat.server.getVideo($('#user-name').html(), $('#search-query').val());
    });
});