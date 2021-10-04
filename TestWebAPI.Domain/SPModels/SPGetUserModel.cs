using System;
using System.Collections.Generic;
using System.Text;

namespace TestWebAPI.Domain.SPModels
{
    public class SPGetUserModel
    {
        public int UserId { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Mobile { get; set; }
    }
}
