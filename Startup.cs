using Microsoft.Owin;
using WebShopping.Models;
using System.Linq;

using Owin;

[assembly: OwinStartupAttribute(typeof(WebShopping.Startup))]
namespace WebShopping
{
    public partial class Startup
    {
        private WebShoppingContext db = new WebShoppingContext();

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //_CreateSort();
        }

        private void _CreateSort()
        {
            var sorts = db.Sorts.ToList();

            if (sorts.Count() > 0)
            {
                return;
            }

            db.Sorts.Add(new Sort() { Name = "IdDESC", DisplayName = "Newest items" });
            db.Sorts.Add(new Sort() { Name = "IdASC", DisplayName = "Oldest items" });
            db.Sorts.Add(new Sort() { Name = "PriceASC", DisplayName = "Price: low to high" });
            db.Sorts.Add(new Sort() { Name = "PriceDESC", DisplayName = "Price: high to low" });
            db.SaveChanges();
        }
    }
}
