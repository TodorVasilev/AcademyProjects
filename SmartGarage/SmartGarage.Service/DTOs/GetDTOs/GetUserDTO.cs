using SmartGarage.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace SmartGarage.Service.DTOs.GetDTOs
{
    public class GetUserDTO
    {
        public GetUserDTO()
        {

        }
        public GetUserDTO(User user)
        {
            this.Id = user.Id;
            this.UserName = user.UserName;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.PhoneNumber = user.PhoneNumber;
            this.Age = user.Age;
            this.DrivingLicenseNumber = user.DrivingLicenseNumber;
            this.Address = user.Address;
            this.Email = user.Email;
        }

        public int Id { get; set; }

        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Family name")]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }

        [Display(Name = "Driving license number")]
        public string DrivingLicenseNumber { get; set; }


        [Display(Name = "Address")]
        public string Address { get; set; }

        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}
