using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackEndProject.Models
{
    public class Schedule
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Days are required")]
        public int Day { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Capacity is required")]
        public int CourseId { get; set; }
        public int RoomId { get; set; }
        public int TrainersId { get; set; }
        public Course Course { get; set; }
        public Room Room { get; set; }
        public Trainers Trainer { get; set; }
    }
}