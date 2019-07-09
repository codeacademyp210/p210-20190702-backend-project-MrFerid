using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackEndProject.Models
{
    public class Cupon
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Name must be less than 100 character")]
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string startDate { get; set; }
        public string EndDate { get; set; }
    }
}