using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndProject.ViewModel
{
    public class RoomVM
    {
        public Room Room { get; set; }
        public List<Room> Rooms { get; set; }
        public string Header { get; set; }
        public string Action { get; set; }
    }
}