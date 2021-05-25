using System;

namespace SmartGarage.Service.QueryObjects
{
    public class CustomerServicesFilterQueryObject
    {
        public int VehicleId { get; set; }

        public DateTime VisitDate { get; set; }
    }
}