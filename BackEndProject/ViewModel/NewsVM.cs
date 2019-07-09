using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndProject.ViewModel
{
    public class NewsVM
    {
        public List<News> News { get; set; }
        public List<Package> Package { get; set; }
    }
}