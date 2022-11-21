using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BANQUANAO.Models
{
    public class Users
    {

        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }

        public string Role { get; set; }

        public string Avatar { get; set; }
        public string Andreas { get; set; }
    }
}