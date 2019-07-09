using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndProject.ViewModel
{
    public class HomeVM
    {
        public List<Users> users { get; set; }
        public List<Trainers> trainers { get; set; }
        public List<Event> events { get; set; }
        public List<Course> course { get; set; }
    }
}