using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShopping.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Transaction Transaction { get; set; }
        public int TransactionId { get; set; }
        public int Quantity { get; set; }
    }
}