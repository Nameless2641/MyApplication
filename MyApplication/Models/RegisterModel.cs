using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyApplication.Models
{
    public class RegisterModel:User
    {
        public RegisterModel() { }
        
        [Compare("Email", ErrorMessage ="Email address doesn't match.")]
        public string ConfirmEmail { get; set; }

        [Compare("Password", ErrorMessage="Confirm password doesn't match.")]
        public string ConfirmPassword { get; set; }
    }
}