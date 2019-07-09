using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndProject.ViewModel
{
    public class SheduleVM
    {
        public Schedule shedule { get; set; }
        public List<Schedule> shedules { get; set; }
        public List<Course> courses { get; set; }
        public List<Room> rooms { get; set; }
        public List<Trainers> trainers { get; set; }
        public string Header { get; set; }
        public string Action { get; set; }
    }
}