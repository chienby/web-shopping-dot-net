using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebShopping.Models;
using X.PagedList;

namespace WebShopping.Controllers
{
    public class CartsController : Controller
    {
        private WebShoppingContext db = new WebShoppingContext();

        // GET: Carts
        public ActionResult Index(int? page)
        {
            var cart = db.Carts.Include(c => c.Product);
            var carts = cart.ToList();
            decimal total = 0;

            foreach(var item in carts)
            {
                total += item.Product.Price * item.Quantity;
            }

            int pageSize = 4;
            int pageNumber = (page ?? 1);

            ViewBag.Total = total;

            return View(carts.ToPagedList(pageNumber, pageSize));
        }

        // POST: Carts/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,ProductId,Quantity")] Cart cart)
        {
            var carts = db.Carts.ToList();
            var found = carts.FirstOrDefault(s => s.ProductId == cart.ProductId);

            if (found != null)
            {
                var item = found;
                item.Quantity += 1;

                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                db.Carts.Add(cart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // POST: Carts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductId, Quantity")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cart).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                Cart cart = db.Carts.Find(id);
                db.Carts.Remove(cart);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
