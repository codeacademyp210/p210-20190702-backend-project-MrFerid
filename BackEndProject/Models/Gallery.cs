using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndProject.Models
{
    public class Gallery
    {
        public int id { get; set; }
        public string image { get; set; }
        public int PackageId { get; set; }
        public Package Package { get; set; }
    }
}