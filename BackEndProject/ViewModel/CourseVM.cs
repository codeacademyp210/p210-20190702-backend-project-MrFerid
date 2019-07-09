using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndProject.ViewModel
{
    public class CourseVM
    {
        public Course Course { get; set; }
        public List<Course> Courses { get; set; }
        public string Header { get; set; }
        public string Action { get; set; }
    }
}