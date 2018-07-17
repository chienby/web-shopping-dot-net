using System.Web.Mvc;

namespace WebShopping.Areas.Clerk
{
    public class ClerkAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Clerk";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Clerk_default",
                "Clerk/{controller}/{action}/{id}",
                new { action = "Index", controller= "Products", id = UrlParameter.Optional },
                new[] { "WebShopping.Areas.Clerk.Controllers" }
            );
        }
    }
}