using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations;

namespace DataLibrary.DataAccess
{
    public class WebsiteContext : DbContext
    {
        public WebsiteContext() : base("MSSQLLocalDB") { }
        public DbSet<AccountModel> Account { get; set; }
        public DbSet<CartItemModel> CartItems { get; set; }
        public DbSet<CartModel> Cart { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<View_ProductStock> View_ProductStock { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<AccountModel>()
              //  .HasRequired(b => b.CartModel)
                //.WithRequiredPrincipal(i => i.Account);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        //public System.Data.Entity.DbSet<DataLibrary.Models.View_ProductStock> View_ProductStock { get; set; }
    }
}
