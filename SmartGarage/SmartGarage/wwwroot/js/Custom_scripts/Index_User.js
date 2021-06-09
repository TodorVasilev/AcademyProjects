$(document).ready(function () {

	$(document).on("click", "#search", function () {
		var name = $('#name').val();
		var phoneNumber = $('#phoneNumber').val();
		var email = $('#email').val();
		var vehicle = $('#vehicle').val();
		var startDate = $('#startDate').val();
		var endDate = $('#endDate').val();
		var orderName = $('#orderName').val();
		var orderDate = $('#orderDate').val();
		$.ajax({
			url: "/User/Search",
			type: "GET",
			data: {
				name: name,
				phoneNumber: phoneNumber,
				email: email,
				vehicle: vehicle,
				startDate: startDate,
				endDate: endDate,
				orderByName: orderName,
				OrderByDate: orderDate
			}
		})
			.done(function (partialViewResult) {
				$("#partialView").html(partialViewResult);
			});
	});

	$(document).on("click", "#next", function () {
		var name = $('#name').val();
		var phoneNumber = $('#phoneNumber').val();
		var email = $('#email').val();
		var vehicle = $('#vehicle').val();
		var startDate = $('#startDate').val();
		var endDate = $('#endDate').val();
		var orderName = $('#orderName').val();
		var orderDate = $('#orderDate').val();
		var page = $('#page').val();
		$.ajax({
			url: "/User/Search",
			type: "GET",
			data: {
				name: name,
				phoneNumber: phoneNumber,
				email: email,
				vehicle: vehicle,
				startDate: startDate,
				endDate: endDate,
				orderByName: orderName,
				OrderByDate: orderDate,
				pageNumber: parseInt(page) + 1
			}
		})
			.done(function (partialViewResult) {
				$("#partialView").html(partialViewResult);
			});
	});
	$(document).on("click", "#prev", function () {
		var name = $('#name').val();
		var phoneNumber = $('#phoneNumber').val();
		var email = $('#email').val();
		var vehicle = $('#vehicle').val();
		var startDate = $('#startDate').val();
		var endDate = $('#endDate').val();
		var orderName = $('#orderName').val();
		var orderDate = $('#orderDate').val();
		var page = $('#page').val();
		$.ajax({
			url: "/User/Search",
			type: "GET",
			data: {
				name: name,
				phoneNumber: phoneNumber,
				email: email,
				vehicle: vehicle,
				startDate: startDate,
				endDate: endDate,
				pageNumber: parseInt(page) - 1
			}
		})
			.done(function (partialViewResult) {
				$("#partialView").html(partialViewResult);
			});
	});
});