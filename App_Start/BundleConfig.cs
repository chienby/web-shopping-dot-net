using System.Web;
using System.Web.Optimization;

namespace WebShopping
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //CLERK

            bundles.Add(new ScriptBundle("~/Content/Clerk/js").Include(
                        "~/Areas/Clerk/Vendor/jquery/jquery.min.js",
                        "~/Areas/Clerk/Vendor/bootstrap/js/bootstrap.bundle.min.js",
                        "~/Areas/Clerk/Vendor/jquery-easing/jquery.easing.min.js",
                        "~/Scripts/respond.js",
                        "~/Areas/Clerk/Vendor/datatables/jquery.dataTables.js",
                        "~/Areas/Clerk/Vendor/datatables/dataTables.bootstrap4.js",
                        "~/Areas/Clerk/Scripts/sb-admin.min.js",
                        "~/Areas/Clerk/Scripts/sb-admin-datatables.js",
                        "~/Scripts/site.js"

            ));

            bundles.Add(new StyleBundle("~/Content/Clerk/css").Include(
                      "~/Areas/Clerk/Content/sb-admin.min.css",
                      "~/Areas/Clerk/Vendor/bootstrap/css/bootstrap.min.css",
                      "~/Areas/Clerk/Vendor/font-awesome/css/font-awesome.min.css",
                      "~/Areas/Clerk/Vendor/datatables/dataTables.bootstrap4.css"
            ));

            //HOME
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                        "~/Scripts/site.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-payment").Include(
                        "~/Scripts/jquery.payment.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-validation-payment").Include(
                       "~/Scripts/jquery.validation-payment.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Vendor/bootstrap/js/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css",
                      "~/Vendor/font-awesome/css/fontawesome-all.css",
                      "~/Vendor/bootstrap/css/bootstrap.css"
            ));

        }
    }
}
