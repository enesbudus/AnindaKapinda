using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace AnindaKapinda.UI.MVC.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Bundles/scripts").Include(
                "~/Assert/Admin/js/jquery.js",
                "~/Assert/Admin/js/jquery-1.8.3.min.js",
                "~/Assert/Admin/js/bootstrap.min.js",
                "~/Assert/Admin/js/jquery.dcjqaccordion.2.7.js",
                "~/Assert/Admin/js/jquery.scrollTo.min.js",
                "~/Assert/Admin/js/jquery.nicescroll.js",
                "~/Assert/Admin/js/jquery.sparkline.js",
                "~/Assert/Admin/assets/jquery-easy-pie-chart/jquery.easy-pie-chart.js",
                "~/Assert/Admin/js/owl.carousel.js",
                "~/Assert/Admin/js/jquery.customSelect.min.js",
                "~/Assert/Admin/js/respond.min.js",
                "~/Assert/Admin/js/jquery.dcjqaccordion.2.7.js",
                "~/Assert/Admin/js/common-scripts.js",
                "~/Assert/Admin/js/sparkline-chart.js",
                "~/Assert/Admin/js/easy-pie-chart.js",
                "~/Assert/Admin/js/count.js"
                ));
            bundles.Add(new StyleBundle("~/Bundles/css").Include(
                "~/Assert/Admin/favicon.ico",
                "~/Assert/Admin/css/bootstrap.min.css",
                "~/Assert/Admin/css/bootstrap-reset.css",
                "~/Assert/Admin/assets/font-awesome/css/font-awesome.css",
                "~/Assert/Admin/assets/jquery-easy-pie-chart/jquery.easy-pie-chart.css",
                "~/Assert/Admin/css/owl.carousel.css",
                "~/Assert/Admin/css/style.css",
                "~/Assert/Admin/css/style-responsive.css"
                ));
            bundles.Add(new StyleBundle("~/BundlesLogin/css").Include(
               "~/Assert/Admin/css/bootstrap.min.css",
                "~/Assert/Login/LoginStyle.css"
               ));
            bundles.Add(new ScriptBundle("~/BundlesLogin/scripts").Include(
        "~/Assert/Admin/js/jquery.min.js"
         ));
            bundles.Add(new StyleBundle("~/BundlesSite/css").Include(
             "~/Assert/Site/css/bootstrap.css",
             "~/Assert/Site/css/style.css",
             "~/Assert/Site/css/font-awesome-4.7.0/css/font-awesome.min.css",
             "~/Assert/Site/css/Site.css"
              ));
            bundles.Add(new ScriptBundle("~/BundlesSite/scripts").Include(
           "~/Assert/Site/js/modernizr.custom.63321.js",
           "~/Assert/Site/js/jquery-1.10.0.min.js",
           "~/Assert/Site/js/jquery-ui.min.js",
           "~/Assert/Site/js/bootstrap.js",
           "~/Assert/Site/js/placeholder.js",
           "~/Assert/Site/js/imagesloaded.pkgd.min.js",
           "~/Assert/Site/js/masonry.pkgd.min.js",
           "~/Assert/Site/js/jquery.swipebox.min.js",
           "~/Assert/Site/js/farbtastic/farbtastic.js",
           "~/Assert/Site/js/options.js",
           "~/Assert/Site/js/plugins.js"
              ));
        }
    }
}