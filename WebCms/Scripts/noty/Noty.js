
var notyModule = (function() {

    var notyMessage = {
        notyMsg: notyMsg
    };

   function notyMsg(message, messageType) {
        noty({
            text: message,
            layout: 'bottomLeft',
            type: messageType,
            timeout: true,
            animation: {
                open: { height: 'toggle' }, // jQuery animate function property object
                close: { height: 'toggle' }, // jQuery animate function property object
                easing: 'swing', // easing
                speed: 800 // opening & closing animation speed
            },
        }).setTimeout(2500);;
    }
    return notyMessage;
})();