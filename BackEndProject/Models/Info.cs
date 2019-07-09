using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackEndProject.Models
{
    public class Info
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Write an Username")]
        [MaxLength(60, ErrorMessage = "Username adress must be less than 60 character")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Write an Email adress")]
        [MaxLength(60,ErrorMessage ="Email adress must be less than 60 character")]
        [EmailAddress(ErrorMessage = "invalid Email adress")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Write an Phone Number")]
        public string Number { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public string City { get; set; }
        public int Pincode { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public string Conditions { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Google { get; set; }
        public string Skype { get; set; }
    }
}