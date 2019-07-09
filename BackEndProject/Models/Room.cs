using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackEndProject.Models
{
    public class Room
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(60,ErrorMessage = "Name must be less than 60 character")]
        public string Name { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}