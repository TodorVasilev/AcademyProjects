using System;
using System.Collections.Generic;
using System.Text;

namespace SmartGarage.Service.QueryObjects
{
    public class CustomerServicesFilterQueryObject
    {
        public int VehicleId { get; }

        public DateTime VisitDate { get; }
    }
}