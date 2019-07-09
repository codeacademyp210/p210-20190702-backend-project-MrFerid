using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackEndProject.Models
{
    public class Calendar
    {
        public int id { get; set; }
        [Required(ErrorMessage ="Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Days are required")]
        public string Day { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public int PackageId { get; set; }
        public Package Package { get; set; }
    }
}