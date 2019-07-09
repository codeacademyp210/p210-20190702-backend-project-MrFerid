using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndProject.ViewModel
{
    public class CuponVM
    {
        public Cupon Cupon { get; set; }
        public List<Cupon> Cupons { get; set; }
        public string Action { get; set; }
        public string Button { get; set; }
        public string Header { get; set; }
    }
}