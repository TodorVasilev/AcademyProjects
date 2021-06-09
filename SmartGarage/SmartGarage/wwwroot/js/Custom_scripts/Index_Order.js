$(document).ready(function () {
    $(document).on("click", "#search", function () {
        var name = $('#name').val();
        $.ajax({
            url: "/Order/Search",
            type: "GET",
            data: {
                name: name
            }
        })
            .done(function (partialViewResult) {
                $("#partialView").html(partialViewResult);
            });
    });
    $(document).on("click", "#next", function () {
        var name = $('#name').val();
        var page = $('#page').val();
        $.ajax({
            url: "/Order/Search",
            type: "GET",
            data: {
                name: name,
                pageNumber: parseInt(page) + 1
            }
        })
            .done(function (partialViewResult) {
                $("#partialView").html(partialViewResult);
            });
    });
    $(document).on("click", "#prev", function () {
        var name = $('#name').val();
        var page = $('#page').val();
        $.ajax({
            url: "/Order/Search",
            type: "GET",
            data: {
                name: name,
                pageNumber: parseInt(page) - 1
            }
        })
            .done(function (partialViewResult) {
                $("#partialView").html(partialViewResult);
            });
    });
});