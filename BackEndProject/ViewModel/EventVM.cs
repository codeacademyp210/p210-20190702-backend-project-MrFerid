using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndProject.ViewModel
{
    public class EventVM
    {
        public Event Event { get; set; }
        public List<Event> Events { get; set; }
        public string Button { get; set; }
        public string Header { get; set; }
        public string Action { get; set; }
    }
}