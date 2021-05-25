using System;

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
