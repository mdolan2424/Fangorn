// Write your Javascript code.




$(document).ready(function () {

    //destroy modal and data to prevent caching.
    $('body').on('hidden.bs.modal', '.modal', function () {
        $(this).removeData('bs.modal');
    });
    

    $('input[type=datetime]').datetimepicker({
        inline: true,
        sideBySide: true
        
    });




    });

    /*$("td").find("div").hide();
    $("table").click(function (event) {
        event.stopPropagation();

        var $target = $(event.target);

 
        $target.closest("tr").find("div").slideToggle();
        


    });*/





    