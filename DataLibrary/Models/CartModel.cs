using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataLibrary.Models
{
    public class CartModel
    {

        [Key] public int CartId { get; set; }
        public int AccountId { get; set; }

        //public AccountModel Account { get; set; }
    }
}
