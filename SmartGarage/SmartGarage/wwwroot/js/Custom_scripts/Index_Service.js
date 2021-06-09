$(document).ready(function () {
    $(document).on("click", "#search", function () {
        var price = $('#price').val();
        var name = $('#name').val();
        $.ajax({
            url: "/Service/Search",
            type: "GET",
            data: {
                price: price,
                name: name
            }
        })
            .done(function (partialViewResult) {
                $("#partialView").html(partialViewResult);
            });
    });
    $(document).on("click", "#next", function () {
        var price = $('#price').val();
        var name = $('#name').val();
        var page = $('#page').val();
        $.ajax({
            url: "/Service/Search",
            type: "GET",
            data: {
                price: price,
                name: name,
                pageNumber: parseInt(page) + 1
            }
        })
            .done(function (partialViewResult) {
                $("#partialView").html(partialViewResult);
            });
    });
    $(document).on("click", "#prev", function () {
        var price = $('#price').val();
        var name = $('#name').val();
        var page = $('#page').val();
        $.ajax({
            url: "/Service/Search",
            type: "GET",
            data: {
                price: price,
                name: name,
                pageNumber: parseInt(page) - 1
            }
        })
            .done(function (partialViewResult) {
                $("#partialView").html(partialViewResult);
            });
    });
});