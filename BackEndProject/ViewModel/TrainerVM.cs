using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndProject.ViewModel
{
    public class TrainerVM
    {
        public Trainers Trainer { get; set; }
        public List<Trainers> Trainers { get; set; }
        public string Header { get; set; }
        public string Action { get; set; }
    }
}