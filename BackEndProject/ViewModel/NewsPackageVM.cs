using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndProject.ViewModel
{
    public class NewsPackageVM
    {
        public News News { get; set; }
        public List<Package> Package { get; set; }
        public string Header { get; set; }
        public string Action { get; set; }
        public string Button { get; set; }
    }
}