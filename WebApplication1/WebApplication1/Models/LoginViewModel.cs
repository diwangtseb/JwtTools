using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [StringLength(100,MinimumLength = 15)]
        public string Loginname { get; set; }
        [Required]
        [StringLength(30,MinimumLength = 10)]
        public string Loginpwd { get; set; }
        public string Id { get; set; }

    }
}



