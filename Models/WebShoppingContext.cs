using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebShopping.Models
{
    public class WebShoppingContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WebShoppingContext() : base("name=WebShoppingContext")
        {

        }

        public System.Data.Entity.DbSet<WebShopping.Models.ShippingAddress> ShippingAddresses { get; set; }

        public System.Data.Entity.DbSet<WebShopping.Models.Cart> Carts { get; set; }

        public System.Data.Entity.DbSet<WebShopping.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<WebShopping.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<WebShopping.Models.Sort> Sorts { get; set; }

        public System.Data.Entity.DbSet<WebShopping.Models.Payment> Payments { get; set; }

        public System.Data.Entity.DbSet<WebShopping.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<WebShopping.Models.Transaction> Transactions { get; set; }
    }
}
