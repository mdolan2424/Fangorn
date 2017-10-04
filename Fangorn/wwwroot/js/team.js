
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




    
});