using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShopping.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public string ShortDescription { get; set; }

        [DataType(DataType.MultilineText)]
        public string LongDescription { get; set; }

    }
}