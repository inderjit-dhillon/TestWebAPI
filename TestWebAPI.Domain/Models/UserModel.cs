using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestWebAPI.Domain.Models
{
    public class UserModel
    {
        public int UserId { get; set; } = 0;
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Mobile { get; set; }
        public bool IsUpdate { get; set; }
    }
}
