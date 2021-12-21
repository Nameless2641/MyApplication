using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyApplication.Models
{
    public class LoginModel
    {
        public LoginModel()
        {
            
        }
        [Required(ErrorMessage = "Enter an email address")]
        public string Mail { get; set; }
        [Required(ErrorMessage ="Enter a Password")]
        public string Password { get; set; }
    }
}