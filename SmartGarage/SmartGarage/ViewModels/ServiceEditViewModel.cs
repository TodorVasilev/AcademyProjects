using System.ComponentModel.DataAnnotations;

namespace SmartGarage.ViewModels
{
    public class ServiceEditViewModel
    {
    [MinLength(3,ErrorMessage ="More than 3 chars.")]
        public string Name { get; set; }

        public decimal? Price { get; set; }
    }
}