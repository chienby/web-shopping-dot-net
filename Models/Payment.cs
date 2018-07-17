using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShopping.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Card on name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Card number")]
        [CreditCard]
        public string CardNumber { get; set; }

        [Required]
        [Display(Name = "Expiration")]
        public string ExpirationDate { get; set; }

        [Required]
        [Display(Name = "CVV")]
        public int CardVerificationValue { get; set; }
    }
}