using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartGarage.ViewModels
{
    public class OrderEditViewModel
    {
        [DisplayName("Order Status:")]
        [Range(1, 3, ErrorMessage = "Status must be between 1 and 3.")]
        public int? OrderStatusId { get; set; }

    }
}
