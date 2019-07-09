using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackEndProject.Models
{
    public class Course
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Duration is required")]
        public int Duration { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public int Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public Package Package { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}