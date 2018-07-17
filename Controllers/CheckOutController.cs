using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using X.PagedList;
using WebShopping.Models;
using System.Text.RegularExpressions;

namespace WebShopping.Controllers
{
    [Authorize]
    public class CheckOutController : Controller
    {
        private WebShoppingContext db = new WebShoppingContext();

        // GET: CheckOut
        public ActionResult Index(int? page)
        {
            if(db.Carts.Count() == 0)
            {
                return RedirectToAction("Index", "Carts");
            }


            int pageSize = 4;
            int pageNumber = (page ?? 1);
            decimal total = 0;

            var cart = db.Carts.Include(c => c.Product);
            var carts = cart.ToList();

            foreach(var item in carts)
            {
                total += item.Product.Price * item.Quantity;
            }

            CheckOutViewModels viewModel = new CheckOutViewModels();
            viewModel.Cart = carts.ToPagedList(pageNumber, pageSize);

            ViewBag.Total = total;
            ViewBag.Count = carts.Count();

            return View(viewModel);

        }

        // POST: CheckOut/Create
        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "FirstName, LastName, Email, PhoneNumber, Address")] ShippingAddress shippingAddress, 
            [Bind(Include = "FullName, CardNumber, ExpirationDate, CardVerificationValue")] Payment payment,
            [Bind(Include = "UserId, Total")] Transaction transaction
        )
        {
            int pageSize = 4;
            int pageNumber = 1;

            var cart = db.Carts;
            var carts = cart.ToList();

            if (ModelState.IsValid)
            {
                // Remove all space from card number
                payment.CardNumber = Regex.Replace(payment.CardNumber, @"\s+", "");

                // Add Shipping Address and Payments
                db.ShippingAddresses.Add(shippingAddress);
                db.Payments.Add(payment);
                db.SaveChanges();

                // Add transaction
                transaction.PaymentId = payment.Id;
                transaction.ShippingAddressId = shippingAddress.Id;

                db.Transactions.Add(transaction);
                db.SaveChanges();

                // Move all data from Carts to Orders
                foreach (var item in carts)
                {
                    db.Orders.Add(new Order()
                    { 
                        ProductId = item.Id,
                        Quantity = item.Quantity,
                        TransactionId = transaction.Id
                    });

                    db.SaveChanges();
                }

                // Delete all item in cart
                cart.RemoveRange(cart.Where(c => c.Id > 0));
                db.SaveChanges();

                return RedirectToAction("Index", "ThankYou");

            }

            carts = cart.Include(c => c.Product).ToList();

            decimal total = 0;

            foreach (var item in carts)
            {
                total += item.Product.Price * item.Quantity;
            }

            CheckOutViewModels viewModel = new CheckOutViewModels();
            viewModel.Cart = carts.ToPagedList(pageNumber, pageSize);

            ViewBag.Total = total;
            ViewBag.Count = carts.Count();

            return View("Index", viewModel);

        }
        
    }
}
