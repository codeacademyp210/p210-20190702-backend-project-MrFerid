using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndProject.ViewModel
{
    public class PaymentVM
    {
        public List<Users> users { get; set; }
        public List<Course> courses { get; set; }
    }
}