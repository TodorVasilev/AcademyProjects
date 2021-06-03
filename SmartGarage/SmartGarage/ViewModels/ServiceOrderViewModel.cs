using SmartGarage.Service.DTOs.GetDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.ViewModels
{
	public class ServiceOrderViewModel
	{
		public List<GetServiceDTO> UsedServices { get; set; }
		public IEnumerable<GetServiceDTO> AvailableServices { get; set; }

		public int AvailableServiceId { get; set; }

		[DisplayName("Customer Name:")]
		public string CustomerName { get; set; }

		[DisplayName("Status:")]
		public string OrderStatus { get; set; }

		[DisplayName("Arrival Date:")]
		public string ArrivalDate { get; set; }

		[DisplayName("Vehicle Number Plate:")]
		public string VehicleNumberPlate { get; set; }

		[DisplayName("Order Id:")]
		public int OrderId { get; set; }

		[DisplayName("Total price:")]
		public decimal TotalPrice { get; set; }

	}
}
