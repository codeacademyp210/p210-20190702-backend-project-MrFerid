using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackEndProject.Models
{
    public class Event
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(100, ErrorMessage = "Name must be less than 100 character")]
        public string Title { get; set; }
        public string Image { get; set; }
        
        public string StartDate { get; set; }
        
        public string EndDate { get; set; }
        public string Description { get; set; }
    }
}