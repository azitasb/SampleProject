using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Sabahat.WebAPI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content").
                Include("~/Content/Site.css", new CssRewriteUrlTransform()).
                Include("~/Content/bootstrap.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/Scripts").
                Include("~/Scripts/jquery-1.10.2.min.js",
                        "~/Scripts/modernizr-2.6.2.js",
                        "~/Scripts/angular.min.js",
                        "~/Scripts/angular-route.min.js",
                        "~/Scripts/angular-animate.min.js",
                        "~/Scripts/angular-aria.min.js",
                        "~/Scripts/angular-sanitize.min.js",
                        "~/Scripts/angular-messages.min.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/angular-ui/ui-bootstrap.min.js",
                        "~/Scripts/angular-ui/ui-bootstrap-tpls.min.js",
                        "~/Scripts/app.js").
                IncludeDirectory("~/Views", "*.js", true));
        }
    }
}