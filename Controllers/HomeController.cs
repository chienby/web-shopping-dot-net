using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopping.Models;
using X.PagedList;

namespace WebShopping.Controllers
{
    public class HomeController : Controller
    {
        private WebShoppingContext db = new WebShoppingContext();

        public ActionResult Index(int? page, string searchString, string sortBy, string category)
        {
            var products = db.Products.Include(p => p.Category);

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Title.Contains(searchString));
            }

            if(!String.IsNullOrEmpty(category) && !category.Equals("All"))
            {
                products = products.Where(p => p.Category.Title == category);
            }

            switch (sortBy)
            {
                case "IdASC":
                    products = products.OrderBy(p => p.Id);
                    break;
                case "IdDESC":
                    products = products.OrderByDescending(p => p.Id);
                    break;
                case "PriceASC":
                    products = products.OrderBy(p => p.Price);
                    break;
                case "PriceDESC":
                    products = products.OrderByDescending(p => p.Price);
                    break;
                default:
                    products = products.OrderByDescending(p => p.Id);
                    break;
            }


            // To reuse search string
            ViewBag.CategoryString = category;
            ViewBag.SortByString = sortBy;
            ViewBag.SearchString = searchString;

            // To render dropdown list
            ViewBag.Category = new SelectList(db.Categories, "Title", "Title");
            ViewBag.SortBy = new SelectList(db.Sorts, "Name", "DisplayName");

            

            int pageSize = 9;
            int pageNumber = (page ?? 1);

            return View(products.ToList().ToPagedList(pageNumber, pageSize));
        }

        
    }
}