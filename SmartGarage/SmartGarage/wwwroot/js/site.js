// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
showInPopup = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $("#form-modal .modal-body").html(res);
            $("#form-modal .modal-title").html(title);
            $("#form-modal").modal('show');
        }
    })
}

$(document).ready(function () {
    var MakeDDL = $("#Make");
    var ModelDDL = $("#Model");
    ModelDDL.prop('disabled', true);
    MakeDDL.change(function () {
        if ($(this).val() == "0") {
            ModelDDL.prop('disabled', true);
            ModelDDL.val("0");
        }
        else {
            $.ajax({
                url: '/Vehicle/VehicleModels/' + $(this).val(),
                type: "GET",
                success: function (data) {
                    ModelDDL.prop('disabled', false);
                    console.log("Success:");
                    ModelDDL.empty();
                    ModelDDL.append($('<option/>', { value: '0', text: '--Select Model--' }));
                    $(data).each(function (index, item) {
                        ModelDDL.append($('<option/>', { value: item.id, text: item.name }));
                    });
                }
            });
        }
    });
});