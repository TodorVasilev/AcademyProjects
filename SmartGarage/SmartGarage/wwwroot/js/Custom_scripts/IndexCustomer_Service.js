$(document).ready(function () {
	$(document).on("click", "#search", function () {
		var number = $('#numberPlate').val();
		var date = $('#date').val();
		$.ajax({
			url: "/Service/SearchCustomer",
			type: "GET",
			data: {
				numberPlate: number,
				date: date
			}
		})
			.done(function (partialViewResult) {
				$("#partialView").html(partialViewResult);
			});
	});
	$(document).on("click", "#next", function () {
		var number = $('#numberPlate').val();
		var date = $('#date').val();
		var page = $('#page').val();
		$.ajax({
			url: "/Service/SearchCustomer",
			type: "GET",
			data: {
				numberPlate: number,
				date: date,
				pageNumber: parseInt(page) + 1
			}
		})
			.done(function (partialViewResult) {
				$("#partialView").html(partialViewResult);
			});
	});
	$(document).on("click", "#prev", function () {
		var number = $('#numberPlate').val();
		var date = $('#date').val();
		var page = $('#page').val();
		$.ajax({
			url: "/Service/SearchCustomer",
			type: "GET",
			data: {
				numberPlate: number,
				date: date,
				pageNumber: parseInt(page) - 1
			}
		})
			.done(function (partialViewResult) {
				$("#partialView").html(partialViewResult);
			});
	});
});