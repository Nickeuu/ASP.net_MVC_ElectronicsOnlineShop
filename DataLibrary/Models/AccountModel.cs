using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataLibrary.Models
{
    public class AccountModel
    {
        [Key] public int AccountId { get; set; }
        [RegularExpression("^([a-zA-Z .&'-]+)$", ErrorMessage = "Invalid First Name")]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Field must be completed!")]
        public string FirstName { get; set; }

        [RegularExpression("^([a-zA-Z .&'-]+)$", ErrorMessage = "Invalid Middle Name")]
        [DataType(DataType.Text)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [RegularExpression("^([a-zA-Z .&'-]+)$", ErrorMessage = "Invalid Last Name")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Field must be completed!")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password should be at last 8 characters!")]
        [Required(ErrorMessage = "Field must be completed!")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Field must be completed!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //public CartModel CartModel { get; set; }


    }
}
