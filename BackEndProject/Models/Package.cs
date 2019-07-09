using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BackEndProject.Models
{
    public class Package
    {
        public int id { get; set; }
        [MaxLength(60,ErrorMessage = "Name must be less than 60 character")]
        [Required(ErrorMessage = "Package name is required")]
        public string Name { get; set; }
        public string Image { get; set; }
        [Display(Name = "Start date")]
        public string StartDate { get; set; }
        [Display(Name = "End date")]
        public string EndDate { get; set; }
        public string Description { get; set; }
        public ICollection<Calendar> Calendar { get; set; }
        public ICollection<Gallery> Gallery { get; set; }
        public ICollection<News> News { get; set; }

    }
}