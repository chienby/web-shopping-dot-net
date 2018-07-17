using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using X.PagedList;

namespace WebShopping.Models
{
    public class CheckOutViewModels
    {
        public IPagedList<Cart> Cart { get; set; }
        public Payment Payment { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
    }
}