$(function () {

    $(".incluir").click(function () {
        $("#modal").load("incluir", function () {
            $("#modal").modal();
        })
    });

    $(".alterar").click(function () {
        var id = $(this).attr("data-id");
        $("#modal").load("alterar/" + id, function () {
            $("#modal").modal();
        })
    });

    $(".deletar").click(function () {
        var id = $(this).attr("data-id");
        $("#modal").load("deletar/" + id, function () {
            $("#modal").modal();
        })
    });

    $(".detalhes").click(function () {
        var id = $(this).attr("data-id");
        $("#modal").load("detalhes/" + id, function () {
            $("#modal").modal();
        })
    });
})