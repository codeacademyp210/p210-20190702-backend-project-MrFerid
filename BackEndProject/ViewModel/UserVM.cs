using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndProject.ViewModel
{
    public class UserVM
    {
        public Users User { get; set; }
        public List<Course> Courses { get; set; }
        public string Header { get; set; }
        public string Action { get; set; }
    }
}