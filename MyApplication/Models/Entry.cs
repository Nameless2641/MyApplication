using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyApplication.Models
{
    public class Entry
    {
        public Entry()
        {
            EntryID = Guid.NewGuid();
        }
        [Key]
        public Guid EntryID { get; set; }
        [Required]
        public Guid UserID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Description { get; set; }

        public virtual User User { get; set; }
    }
}