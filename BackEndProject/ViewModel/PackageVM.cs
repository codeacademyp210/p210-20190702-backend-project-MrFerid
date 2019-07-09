using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndProject.ViewModel
{
    public class PackageVM
    {
        public Package package { get; set; }
        public List<Package> packages { get; set; }
        public string Action { get; set; }
        public string Button { get; set; }
    }
}