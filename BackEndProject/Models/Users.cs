using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackEndProject.Models
{
    public class Users
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Name must be less than 100 character")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Write an Email adress")]
        [MaxLength(60, ErrorMessage = "Email adress must be less than 60 character")]
        [EmailAddress(ErrorMessage = "invalid Email adress")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Number is required")]
        public string Number { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public DateTime RegisterDate { get; set; }
        public string City { get; set; }
        public int Pincode { get; set; }
        public string Country { get; set; }
        public string Image { get; set; }
        public int Payment { get; set; }
        public string Status { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}