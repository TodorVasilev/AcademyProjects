using SmartGarage.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartGarage.Service.DTOs
{
    public class UserAuthDTO
    {
        public UserAuthDTO(User user)
        {
            this.UserName = user.UserName;
        }

        [Required]
        [MinLength(2), MaxLength(20)]
        public string UserName { get; set; }

        public string Token { get; set; }
    }
}
