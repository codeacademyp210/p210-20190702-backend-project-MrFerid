using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BackEndProject.Models
{
    public class News
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(100, ErrorMessage = "Title must be less than 100 character")]
        public string Title { get; set; }
        public string Image { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public int PackageId { get; set; }
        public Package Package { get; set; }
    }
}