using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackEndProject.Models
{
    public class Trainers
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Name must be less than 100 character")]
        public string FullName { get; set; }
        public ICollection<Schedule> Schedule { get; set; }
    }
}