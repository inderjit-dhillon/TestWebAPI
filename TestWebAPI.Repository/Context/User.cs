using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TestWebAPI.Repository.Context
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        [DataType("varchar(100)")]
        public string Name { get; set; }
        [DataType("varchar(100)")]
        public string Email { get; set; }
        [DataType("varchar(100)")]
        public string Password { get; set; }
        [DataType("varchar(100)")]
        public string City { get; set; }
        [DataType("varchar(100)")]
        public string Mobile { get; set; }

        [DefaultValue(false)]
        public bool? IsDelete { get; set; }
       
        public int RoleId { get; set; }
    }
}
