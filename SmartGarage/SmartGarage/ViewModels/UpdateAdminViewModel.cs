using System.ComponentModel.DataAnnotations;

namespace SmartGarage.ViewModels
{
    public class UpdateAdminViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
