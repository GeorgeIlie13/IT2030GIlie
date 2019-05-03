
function searchFailed() {

    $("#searchresults").html("Search Failed. Please Try Again.");
}


$(function () {

    $(".RemoveLink").click(function () {

       
        var id = $(this).attr("data-id");
        $.post("/Order/RemoveFromOrder", { "id": id }, function (data) {

        
            $("#update-message").text(data.Message);

            $("#item-count-" + data.DeleteId).text(0);

            $("#status-" + data.DeleteId).text(data.Status); 


        });

        $(this).hide();

    })


});

$(function () {

    $(".RemoveButton").click(function () {


        var id = $(this).attr("data-id");
        $.post("/Order/RemoveFromOrder", { "id": id }, function (data) {


            $("#update-message").text(data.Message);
            $("#status").text(data.Status);


        });

        $(this).hide();

    })


});

