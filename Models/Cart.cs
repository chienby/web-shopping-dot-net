using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShopping.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}