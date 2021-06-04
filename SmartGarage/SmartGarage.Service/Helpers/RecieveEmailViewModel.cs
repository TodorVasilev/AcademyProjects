using System.ComponentModel.DataAnnotations;

namespace SmartGarage.Service.Helpers
{
    public class RecieveEmailViewModel
    {
        [Required]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "{0} must be between {2} and {1} symbols.")]
        public string PersonName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} symbols.")]
        public string PersonEmail { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "{0} must be between {2} and {1} symbols.")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "{0} must be between {2} and {1} symbols.")]
        public string Message { get; set; }
    }
}
