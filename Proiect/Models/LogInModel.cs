using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Proiect.Models
{
    public class LogInModel
    {
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password should be at last 8 characters!")]
        [Required(ErrorMessage = "Field must be completed!")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Field must be completed!")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}