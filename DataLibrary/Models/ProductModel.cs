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
    public class ProductModel
    {

        [Key] public int ProductId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
    }
}
