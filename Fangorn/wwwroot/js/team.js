
$(function () {

    function moveUsers(source, destination) {
        $(source).find(":selected").appendTo(destination);
    }



    $('#left').click(function () {
        moveUsers('#Users', '#Members');
    });

    $('#right').on('click', function () {
        moveUsers('#Members', '#Users');
    });

    $('#leftall').on('click', function () {
        moveUsers('#sbTwo', '#sbOne');
    });

    $('#rightall').on('click', function () {
        moveUsers('#sbOne', '#sbTwo');
    });
});