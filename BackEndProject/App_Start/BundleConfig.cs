using System.Web;
using System.Web.Optimization;

namespace BackEndProject
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Scripts/jquery.min.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/custom_js/app.js",
                        "~/Scripts/custom_js/metisMenu.js",
                        "~/Content/vendors/holder/holder.js",
                        "~/Scripts/Ajax.js"
                        ));

           

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/font-awesome.min.css",
                      "~/Content/css/custom_css/metisMenu.css",
                      "~/Content/css/custom_css/fitness.css"
                      ));
        }
    }
}
