using System;

namespace SmartGarage.Service.QueryObjects
{
    public class UserSevicesFillterQueryObject
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Vehicle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
