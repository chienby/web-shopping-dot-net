using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShopping.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public Payment Payment { get; set; }
        public int PaymentId { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        public int ShippingAddressId { get; set; }
        public string UserId { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; }

        public Transaction()
        {
            CreatedAt = DateTime.Now;
        }
    }
}