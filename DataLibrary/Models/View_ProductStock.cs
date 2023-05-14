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
    public class View_ProductStock
    {
        [Key] public int ProductId { get; set; }
        public string Title { get; set; }
        public int Stock { get; set; }
    }
}
