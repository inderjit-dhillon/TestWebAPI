using System;
using System.Collections.Generic;
using System.Text;

namespace TestWebAPI.Domain.OutputModels
{
    public class UserResModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Mobile { get; set; }
        public int RoleId { get; set; }
    }
}
