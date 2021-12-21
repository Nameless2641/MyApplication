using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyApplication.Models
{
    public class User
    {
        public User()
        {
            UserID = Guid.NewGuid();
            
            Banned = false;
            BanDuration = DateTime.Today.AddDays(-1);
            PasswordReset = false;
            PasswordResetDuration = DateTime.Today.AddDays(-1);
            IsAdmin = false;
            SignupDate = DateTime.Now;
            EmailVerified = false;
        }
        [Key]//primärnyckel
        public Guid UserID { get; set; }
        [StringLength(20, ErrorMessage ="Username must be shorter than 20 characters")] //ska generera något fel om längd är satt som max, därav begränsning. Kan även ta lite för mycket plats
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        [StringLength(450)]
        public string Phonenumber { get; set; }
        [Required]
        [StringLength(450)]
        [EmailAddress]
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        [Required]
        public string Password { get; set; }
        public bool PasswordReset { get; set; }
        public DateTime PasswordResetDuration { get; set; }
        public string PasswordResetToken { get; set; }
        //public string Password2 { get; set; }
        
        public bool Banned { get; set; }
        public DateTime BanDuration { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime SignupDate { get; set; }
        public virtual ICollection<Entry> Entries { get; set; }
        

    }
}