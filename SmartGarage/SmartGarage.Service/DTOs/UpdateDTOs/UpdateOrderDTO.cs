using System;
using System.Collections.Generic;
using System.Text;

namespace SmartGarage.Service.DTOs.UpdateDTOs
{
    public class UpdateOrderDTO
    {
        public int GarageId { get; set; }

        public int OrderStatusId { get; set; }

        public int VehicleId { get; set; }

        public DateTime? FinishDate { get; set; }
    }
}
