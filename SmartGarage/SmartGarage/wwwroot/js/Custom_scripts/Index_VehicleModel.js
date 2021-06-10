$(document).ready(function () {

	$(document).on("click", "#next", function () {
		var page = $('#page').val();
		$.ajax({
			url: "/VehicleModel/Get",
			type: "GET",
			data: {
				pageNumber: parseInt(page) + 1
			}
		})
			.done(function (partialViewResult) {
				$("#partialView").html(partialViewResult);
			});
	});
	$(document).on("click", "#prev", function () {
		var page = $('#page').val();
		$.ajax({
			url: "/VehicleModel/Get",
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